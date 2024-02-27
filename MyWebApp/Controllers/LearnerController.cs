using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Models;
using System.Linq;

namespace MyWebApp.Controllers
{
	public class LearnerController : Controller
	{
		private readonly SchoolContext _context;

		public LearnerController(SchoolContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			var learners = _context.Learners.Include(m => m.Major).ToList();
			return View(learners);
		}

		public IActionResult Delete(int id)
		{
			var learner = _context.Learners
				.Include(l => l.Major)
				.Include(e => e.Enrollments)
				.FirstOrDefault(m => m.LearnerID == id);

			if (learner == null)
			{
				return NotFound();
			}

			if (learner.Enrollments.Any())
			{
				return Content("This learner has some enrollments, can't delete");
			}

			return View(learner);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(int id)
		{
			var learner = _context.Learners.Find(id);
			if (learner == null)
			{
				return NotFound();
			}

			_context.Learners.Remove(learner);
			_context.SaveChanges();

			return RedirectToAction(nameof(Index));
		}

		public IActionResult Edit(int id)
		{
			var learner = _context.Learners.Find(id);
			if (learner == null)
			{
				return NotFound();
			}

			ViewBag.MajorId = new SelectList(_context.Majors, "MajorID", "MajorName", learner.MajorID);
			return View(learner);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(int id, [Bind("LearnerID,FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
		{
			if (id != learner.LearnerID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(learner);
					_context.SaveChanges();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!LearnerExists(learner.LearnerID))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewBag.MajorID = new SelectList(_context.Majors, "MajorID", "MajorName", learner.MajorID);
			return View(learner);
		}

		public IActionResult Create()
		{
			ViewBag.MajorID = new SelectList(_context.Majors, "MajorID", "MajorName");
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create([Bind("FirstMidName,LastName,MajorID,EnrollmentDate")] Learner learner)
		{
			if (ModelState.IsValid)
			{
				_context.Learners.Add(learner);
				_context.SaveChanges();
				return RedirectToAction(nameof(Index));
			}
			ViewBag.MajorID = new SelectList(_context.Majors, "MajorID", "MajorName", learner.MajorID);
			return View(learner);
		}

		private bool LearnerExists(int id)
		{
			return _context.Learners.Any(e => e.LearnerID == id);
		}
	}
}
