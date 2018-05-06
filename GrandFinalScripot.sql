create function [dbo].[NextCustomerNumber]() 
returns char(5) 
as 
begin 
	declare @lastval char(5) 
	set @lastval = (select years from aspy) 
	if @lastval is null set @lastval = 'C0001' 
	declare @i int 
	set @i = right(@lastval,4) + 1 
	return 'C' + right('000' + convert(varchar(10),@i),4) 
end






GO
/****** Object:  Table [dbo].[t_course]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_course](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Credit] [numeric](18, 0) NOT NULL,
	[Description] [varchar](150) NULL,
	[DepartmentId] [int] NOT NULL,
	[SemesterId] [int] NOT NULL,
 CONSTRAINT [PK_t_course] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_department]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[cd]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[cd] as
select d.Id as DepartmentId,d.Code as DepartmentCode,d.Name as DepartmentName,c.Id as CourseId,c.Code as CourseCode,c.Name as CourseName
from t_department as d inner join t_course as c on d.Id=c.DepartmentId




GO
/****** Object:  Table [dbo].[t_student]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationNo] [varchar](150) NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[Date] [date] NULL,
	[Address] [varchar](50) NULL,
	[DepartmentId] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[cds]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[cds] as
select s.RegistrationNo,s.Name as StudentName,s.Email, cd.DepartmentId,DepartmentCode,DepartmentName,CourseId,CourseCode,CourseName from cd join t_student s on cd.DepartmentId=s.DepartmentId






GO
/****** Object:  Table [dbo].[t_courseassingtoteacher]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_courseassingtoteacher](
	[TeacherId] [int] NULL,
	[CourseId] [int] NULL,
	[Status] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_teacher]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_teacher](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Address] [varchar](150) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[ContactNo] [varchar](50) NOT NULL,
	[DesignationId] [int] NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[CreditTobeTaken] [numeric](18, 0) NOT NULL,
	[RemainingCredit] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_t_teacher] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[cat]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[cat] as
SELECT        dbo.t_courseassingtoteacher.TeacherId, dbo.t_teacher.Name, dbo.t_courseassingtoteacher.CourseId,dbo.t_courseassingtoteacher.Status
FROM            dbo.t_courseassingtoteacher INNER JOIN
                         dbo.t_teacher ON dbo.t_courseassingtoteacher.TeacherId = dbo.t_teacher.Id




GO
/****** Object:  Table [dbo].[t_semester]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_semester](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_semester] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[dog]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[dog] as
select c.Id as CourseId,c.Code as CourseCode,c.Name as CourseName,s.Name as Semester,c.DepartmentId from t_semester as s join t_course as c   on c.SemesterId=s.Id




GO
/****** Object:  View [dbo].[v_dogcat]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[v_dogcat] as
select dog.CourseCode,dog.CourseName,dog.Semester,dog.DepartmentId,cat.Name as TeacherName,cat.Status from dog left outer join cat 
on cat.CourseId=dog.CourseId





GO
/****** Object:  View [dbo].[x1]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[x1] as
select s.RegistrationNo,s.Name,s.Email,d.Name as DepartmentName,d.Id as DepartmentId 
from t_student as s join t_department as d on s.DepartmentId=d.Id




GO
/****** Object:  Table [dbo].[enrollcourse]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[enrollcourse](
	[RegistrationNo] [varchar](50) NULL,
	[CorseId] [int] NULL,
	[Date] [date] NULL,
	[Status] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[x2]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[x2] as
select c.Id as CourseId,c.Code as CourseCode,c.Name as CourseName,c.DepartmentId,e.RegistrationNo,e.Status from t_course as c join enrollcourse as e on c.Id=e.CorseId




GO
/****** Object:  View [dbo].[SCDx1x2]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create view [dbo].[SCDx1x2] as
select x1.RegistrationNo,x1.Name,x1.Email,x1.DepartmentName,x2.CourseId,x2.CourseCode,x2.CourseName,x2.Status
from x1 inner join x2 on x1.RegistrationNo=x2.RegistrationNo


GO
/****** Object:  Table [dbo].[t_allocateclassroom]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_allocateclassroom](
	[DepartmentId] [int] NULL,
	[CourseId] [int] NULL,
	[RoomId] [int] NULL,
	[DayId] [int] NULL,
	[FromTime] [time](7) NULL,
	[ToTime] [time](7) NULL,
	[Status] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[v_allocateclassroom]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[v_allocateclassroom] as
select tc.DepartmentId,tc.Id as CourseId ,ta.RoomId,ta.DayId,ta.FromTime,ta.ToTime,ta.Status from 
t_course as tc left outer join t_allocateclassroom as ta on tc.Id=ta.CourseId

GO
/****** Object:  Table [dbo].[t_day]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_day](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Day] [varchar](50) NULL,
 CONSTRAINT [PK_t_day] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_room]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_room](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoomNo] [varchar](50) NULL,
 CONSTRAINT [PK_t_room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[acrdr]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[acrdr] as
select acr.DepartmentId,t_day.Day,t_room.RoomNo,acr.CourseId,acr.FromTime,acr.ToTime,acr.Status from v_allocateclassroom as acr left outer join t_day  on t_day.Id=acr.DayId  left outer join t_room on t_room.Id=acr.RoomId


GO
/****** Object:  View [dbo].[dc]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[dc] as
select c.DepartmentId, d.Name as DepartmentName,c.Id as CourseId,c.Code as CourseCode,c.Name as CourseName from t_department as d join t_course as c on d.Id=c.DepartmentId 



GO
/****** Object:  View [dbo].[student_department]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[student_department] as
select s.Id as StudentId,s.RegistrationNo,s.Name,s.Email,s.DepartmentId,d.Code as DepartmentCode,d.Name as DepartmentName
from t_student as s join t_department as d on s.DepartmentId=d.Id




GO
/****** Object:  Table [dbo].[t_studentresult]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_studentresult](
	[RegistrationNo] [varchar](50) NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[DepartmentName] [varchar](50) NULL,
	[CourseId] [int] NULL,
	[Grade] [varchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[viewresult]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[viewresult] as
select e.RegistrationNo,s.Name,s.Email,s.DepartmentName,c.Id as CourseId,c.Code as CourseCode,c.Name as CourseName,s.Grade,e.Status from enrollcourse as e  join t_course as c on c.Id=e.CorseId
left outer join t_studentresult as s on c.Id=s.CourseId




GO
/****** Object:  View [dbo].[schedule]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




create view [dbo].[schedule] as
select dc.DepartmentId,dc.CourseCode,dc.CourseName,r.RoomNo,d.Day,al.FromTime,al.ToTime,al.Status 
from v_allocateclassroom as al join t_room r on al.RoomId=r.Id join t_day as d on d.Id=al.DayId
 right outer join dc on dc.CourseId=al.CourseId 





GO
/****** Object:  Table [dbo].[t_designation]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_designation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_t_designation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[t_grade]    Script Date: 9/3/2016 1:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[t_grade](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Grade] [varchar](50) NULL,
 CONSTRAINT [PK_t_grade] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[t_day] ON 

INSERT [dbo].[t_day] ([Id], [Day]) VALUES (1, N'Saturday')
INSERT [dbo].[t_day] ([Id], [Day]) VALUES (2, N'Sunday')
INSERT [dbo].[t_day] ([Id], [Day]) VALUES (3, N'Monday')
INSERT [dbo].[t_day] ([Id], [Day]) VALUES (4, N'Tuesday')
INSERT [dbo].[t_day] ([Id], [Day]) VALUES (5, N'Wednesday')
INSERT [dbo].[t_day] ([Id], [Day]) VALUES (6, N'Thursday')
INSERT [dbo].[t_day] ([Id], [Day]) VALUES (7, N'Friday')
SET IDENTITY_INSERT [dbo].[t_day] OFF
SET IDENTITY_INSERT [dbo].[t_designation] ON 

INSERT [dbo].[t_designation] ([Id], [Name]) VALUES (1, N'Lecturer')
INSERT [dbo].[t_designation] ([Id], [Name]) VALUES (2, N'Chairman')
INSERT [dbo].[t_designation] ([Id], [Name]) VALUES (3, N'Assistent Professor')
SET IDENTITY_INSERT [dbo].[t_designation] OFF
SET IDENTITY_INSERT [dbo].[t_grade] ON 

INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (1, N'A+')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (2, N'A')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (3, N'A-')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (4, N'B+')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (5, N'B')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (6, N'B-')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (7, N'C+')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (8, N'C')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (9, N'C-')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (10, N'D+')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (11, N'D')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (12, N'D-')
INSERT [dbo].[t_grade] ([Id], [Grade]) VALUES (13, N'F')
SET IDENTITY_INSERT [dbo].[t_grade] OFF
SET IDENTITY_INSERT [dbo].[t_room] ON 

INSERT [dbo].[t_room] ([Id], [RoomNo]) VALUES (1, N'A-101')
INSERT [dbo].[t_room] ([Id], [RoomNo]) VALUES (2, N'A-102')
INSERT [dbo].[t_room] ([Id], [RoomNo]) VALUES (3, N'A-103')
INSERT [dbo].[t_room] ([Id], [RoomNo]) VALUES (4, N'B-101')
INSERT [dbo].[t_room] ([Id], [RoomNo]) VALUES (5, N'B-102')
INSERT [dbo].[t_room] ([Id], [RoomNo]) VALUES (6, N'B-103')
INSERT [dbo].[t_room] ([Id], [RoomNo]) VALUES (7, N'C-101')
INSERT [dbo].[t_room] ([Id], [RoomNo]) VALUES (8, N'C-102')
INSERT [dbo].[t_room] ([Id], [RoomNo]) VALUES (9, N'C-103')
SET IDENTITY_INSERT [dbo].[t_room] OFF
SET IDENTITY_INSERT [dbo].[t_semester] ON 

INSERT [dbo].[t_semester] ([Id], [Name]) VALUES (1, N'semester1')
INSERT [dbo].[t_semester] ([Id], [Name]) VALUES (2, N'semester2')
INSERT [dbo].[t_semester] ([Id], [Name]) VALUES (3, N'semseter3')
INSERT [dbo].[t_semester] ([Id], [Name]) VALUES (4, N'semseter4')
INSERT [dbo].[t_semester] ([Id], [Name]) VALUES (5, N'semseter5')
INSERT [dbo].[t_semester] ([Id], [Name]) VALUES (6, N'semseter6')
INSERT [dbo].[t_semester] ([Id], [Name]) VALUES (7, N'semseter7')
INSERT [dbo].[t_semester] ([Id], [Name]) VALUES (8, N'semseter8')
SET IDENTITY_INSERT [dbo].[t_semester] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [Code_t_department]    Script Date: 9/3/2016 1:43:19 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Code_t_department] ON [dbo].[t_department]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [Name_t_department]    Script Date: 9/3/2016 1:43:19 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [Name_t_department] ON [dbo].[t_department]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_t_student]    Script Date: 9/3/2016 1:43:19 PM ******/
CREATE NONCLUSTERED INDEX [IX_t_student] ON [dbo].[t_student]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[t_course]  WITH CHECK ADD  CONSTRAINT [FK_t_course_t_department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[t_department] ([Id])
GO
ALTER TABLE [dbo].[t_course] CHECK CONSTRAINT [FK_t_course_t_department]
GO
ALTER TABLE [dbo].[t_course]  WITH CHECK ADD  CONSTRAINT [FK_t_course_t_semester] FOREIGN KEY([SemesterId])
REFERENCES [dbo].[t_semester] ([Id])
GO
ALTER TABLE [dbo].[t_course] CHECK CONSTRAINT [FK_t_course_t_semester]
GO
ALTER TABLE [dbo].[t_teacher]  WITH CHECK ADD  CONSTRAINT [FK_t_teacher_t_department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[t_department] ([Id])
GO
ALTER TABLE [dbo].[t_teacher] CHECK CONSTRAINT [FK_t_teacher_t_department]
GO
ALTER TABLE [dbo].[t_teacher]  WITH CHECK ADD  CONSTRAINT [FK_t_teacher_t_designation] FOREIGN KEY([DesignationId])
REFERENCES [dbo].[t_designation] ([Id])
GO
ALTER TABLE [dbo].[t_teacher] CHECK CONSTRAINT [FK_t_teacher_t_designation]