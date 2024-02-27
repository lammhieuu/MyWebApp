CREATE DATABASE MyWebApp1; 

USE [MyWebApp1];  

CREATE TABLE Major (
    MajorID int NOT NULL PRIMARY KEY,
    MajorName varchar(50) NOT NULL
);


CREATE TABLE Course (
    CourseID int NOT NULL PRIMARY KEY,
    Title varchar(50) NOT NULL,
    Credits int NOT NULL
);


CREATE TABLE Learner (
    LearnerID int NOT NULL PRIMARY KEY IDENTITY(1,1),
    LastName varchar(50) NOT NULL,
    FirstMidName varchar(50) NOT NULL,
    EnrollmentDate date NOT NULL,
    MajorID int NULL,  
    FOREIGN KEY (MajorID) REFERENCES Major(MajorID) ON DELETE SET NULL
);


CREATE TABLE Enrollment (
    EnrollmentID int NOT NULL PRIMARY KEY IDENTITY(1,10),
    CourseID int NOT NULL,
    LearnerID int NOT NULL,
    Grade float NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Course(CourseID),
    FOREIGN KEY (LearnerID) REFERENCES Learner(LearnerID)
);

