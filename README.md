# Basic-Math
Advance Web Programming Project made with ASP.NET MVC

## Courses
1. Arithmetic Operations
2. Rounding Numbers, Find Percentage, Write Numbers in Words
3. Finding Area
4. Finding Perimeter
5. Number Systems
6. Probabilities
7. Algebra
8. Sets
9. Statistics
10. LCM and GCF
11. Fractions
12. Finding Volume
## Features
1. Each course include topics to read, randomly generated quiz, dashboard and leaderboard.
2. Questions, solutions and answers on quizzes are randomly generated.
3. Some courses are locked at first but you can buy some course by earning scores in quiz.
4. There are 66 achievements you can complete.
5. There is collections page that you can see all the badges you earned from achievements and certificates from reaching level 20 on a course.
6. You can save your data such as scores, levels, achievements completed, topics read, collected certificates in database by making your own account.
7. There is a profile page where you can see all the progress you have done on the app.
8. You can compete your course level with other users by the leaderboard feature of the app.
9. JavaScript code that track your time in a topic, that if you reach 30 seconds that still on the page will make that topic mark as read.
10. Some courses like algebra and sets are hard to predict answer because of ordering and some unexpected spaces. The system will check for that and your input will consider it correct even in different ordering and some random spacing as long as it is match to the answer.
11. There is a test feature that you can specify the topics, items and difficulty of a quiz you want to take.
## Setup
Create Database `CREATE DATABASE BasicMath;`
Create Table `CREATE TABLE [dbo].[Table] (
Id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
Username varchar(50) NOT NULL,
Email varchar(50) NOT NULL,
Password varchar(100) NOT NULL,
Data text,
AriLevel int,
RouLevel int,
NumLevel int,
ProLevel int,
LcmLevel int,
PerLevel int,
AreLevel int,
VolLevel int,
FraLevel int,
FacLevel int,
SetLevel int,
StaLevel int
);`
