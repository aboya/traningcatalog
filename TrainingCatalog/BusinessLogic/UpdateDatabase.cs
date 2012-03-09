using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingCatalog.BusinessLogic
{

    public static class UpdateDatabase
    {
        private static Dictionary<double, string> sql = new Dictionary<double, string>();
        static UpdateDatabase()
        {
            sql[3] = @"CREATE TABLE Training
                        (
                            Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
                            Day datetime not null CONSTRAINT IX_Training_Day UNIQUE,
                            Comment nvarchar(1000) NOT NULL default '',
                            BodyWeight float null
                        )";
            sql[4] = @"CREATE TABLE Exersize
                            (
                               Id int NOT NULL identity(1,1) constraint PK_Exersize_Id PRIMARY KEY,
                               ShortName nvarchar(100) not null default '',
                               Description nvarchar(2000) NOT NULL default '',
                               Img Image null
                            )";
            sql[5] = @"CREATE TABLE Link
                    (
                       Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
                       TrainingId int not null CONSTRAINT FK_Link_TrainingId references Training (Id),
                       ExersizeId int NOT NULL Constraint FK_Link_ExersizeId references Exersize (Id),
                       Weight int not null,
                       [Count] int not null

                    )";
            sql[6] = @"CREATE TABLE ExersizeCategory
                    (
                       Id int NOT NULL identity(1,1) constraint PK_ExersizeCategoryLink_Id PRIMARY KEY,
                       Name nvarchar(100) not null
                    )";
            sql[6.01] = @"insert into exersizecategory (Name) values('Верхняя часть спины')";
            sql[6.02] = @"insert into exersizecategory (Name) values('Средняя часть спины')";

            sql[6.03] = @"insert into exersizecategory (Name) values('Нижняя часть спины')";
            sql[6.04] = @"insert into exersizecategory (Name) values('Спина')";
            sql[6.05] = @"insert into exersizecategory (Name) values('Плечи')";
            sql[6.06] = @"insert into exersizecategory (Name) values('Ноги')";
            sql[6.07] = @"insert into exersizecategory (Name) values('Пресс')";
            sql[6.08] = @"insert into exersizecategory (Name) values('Икры')";
            sql[6.09] = @"insert into exersizecategory (Name) values('Грудь')";
            sql[6.10] = @"insert into exersizecategory (Name) values('Бицепц')";
            sql[6.11] = @"insert into exersizecategory (Name) values('Трицепц')";
            sql[6.12] = @"insert into exersizecategory (Name) values('Предплечья')";
            sql[6.13] = @"insert into exersizecategory (Name) values('Руки')";

            sql[6.14] = @"insert into Exersize (ShortName) values('Жим штанги лёжа')";
            sql[6.15] = @"insert into Exersize (ShortName) values('Жим штанги сидя')";
            sql[6.16] = @"insert into Exersize (ShortName) values('Подъем штанги стоя на бицепц')";
            sql[6.17] = @"insert into Exersize (ShortName) values('Приседания со штангой')";
            sql[6.18] = @"insert into Exersize (ShortName) values('Становая тяга')";
            sql[6.19] = @"insert into Exersize (ShortName) values('Жим гантелей лёжа')";
            sql[6.20] = @"insert into Exersize (ShortName) values('Жим гантелей сидя')";
            sql[6.21] = @"insert into Exersize (ShortName) values('Подтягивания')";
            sql[6.22] = @"insert into Exersize (ShortName) values('Французский жим')";
            sql[6.23] = @"insert into Exersize (ShortName) values('Тяга штанги к поясу в наклоне')";
            sql[6.24] = @"insert into Exersize (ShortName) values('Тяга штанги к подбородку')";
            sql[6.25] = @"insert into Exersize (ShortName) values('Разведене гантелей стоя в наклоне')";
            sql[6.26] = @"insert into Exersize (ShortName) values('Разгибание ног на тренажере сидя')";
            sql[6.27] = @"insert into Exersize (ShortName) values('Разведение гантелей лёжа')";
            sql[6.28] = @"insert into Exersize (ShortName) values('Подъем гантелей на бицепц')";
            sql[6.29] = @"insert into Exersize (ShortName) values('Трицепц у блока стоя')";
            sql[6.30] = @"insert into Exersize (ShortName) values('Тяга ветрикального блока за голову')";
            sql[6.31] = @"insert into Exersize (ShortName) values('Тяга вертикального блока к животу')";

            sql[7] = @"CREATE TABLE ExersizeCategoryLink
                        (
                           Id int NOT NULL identity(1,1) constraint PK_ExersizeCategoryLink_Id PRIMARY KEY,
                           ExersizeId int not null CONSTRAINT FK_ExersizeCategoryLink_ExersizeId references Exersize (id),
                           ExersizeCategoryId int not null constraint FK_ExersizeCategoryLink_ExersizeCategoryId references ExersizeCategory (id)
                        )";
            sql[8] = @"CREATE TABLE TrainingTemplate
                    (
                       Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
                       TemplateId int not null CONSTRAINT FK_TrainingTemplate_TemplateId references Training (Id),
                       ExersizeId int NOT NULL Constraint FK_TrainingTemplate_ExersizeId references Exersize (Id),
                       Weight int not null,
                       [Count] int not null
                    )";
            sql[9] = @"CREATE TABLE Template
                        (
                           Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
                           Name nvarchar(100) not null 
                        )";
            sql[10] = @"Create table BodyMeasurement (
	                Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
                    TrainingId int not null CONSTRAINT FK_BodyMeasurement_TrainingId references Training (Id),
	                Waistline_h float constraint DF_Waistline_h default(0),
	                Waistline_l float constraint DF_Waistline_l default(0),
	                Biceps_h float constraint DF_Biceps_h default(0),
	                Biceps_l float constraint DF_Biceps_l default(0),
	                Chest_h float constraint DF_Chest_h default(0),
	                Chest_l float constraint DF_Chest_l default(0),
	                Hip_h float constraint DF_Hip_h default(0),
	                Hip_l float constraint DF_Hip_l default(0),
	                Midarm_l float constraint DF_Midarm_l default(0),
	                Midarm_h float constraint DF_Midarmd_l default(0),
	                BodyFat float constraint DF_BodyFat default(0)
                )";
            sql[11] = @"CREATE UNIQUE NONCLUSTERED INDEX IDX_BodyMeasurement_TrainingId ON BodyMeasurement (TrainingId DESC)
                                                    WITH (STATISTICS_NORECOMPUTE = OFF)";
            sql[12.1] = @"CREATE TABLE CardioType
                        (
                           Id int NOT NULL identity(1,1) constraint PK_CardioType_Id PRIMARY KEY,
                           Name nvarchar(100) not null,
                           Velocity bit not null,
                           Time bit not null,
                           Distance bit not null, 
                           Intensivity bit not null CONSTRAINT DF_CardioType_Intensivity default (1),    
                           Resistance bit not null,
                           HeartRate bit not null
                        )";
            sql[13] = @"CREATE TABLE CardioSession
                    (
                       Id int NOT NULL identity(1,1) constraint PK_CardioSession_Id PRIMARY KEY,
                       TrainingId int not null CONSTRAINT FK_CardioSession_TrainingId references Training (Id),
                       StartTime int,
                       EndTime int
                    )";
            sql[14] = @"CREATE TABLE CardioInterval
                        (
                           Id int NOT NULL identity(1,1) constraint PK_CardioSession_Id PRIMARY KEY,
                           CardioSessionId int not null CONSTRAINT FK_CardioInterval_CardioSessionId references CardioSession (Id),   CardioTypeId int not null constraint FK_CardioSession_CardioTypeId references CardioType (Id),
                           Velocity float ,
                           Time float,
                           Distance float,
                           Intensivity float,
                           Resistance float,
                           HeartRate float
                        )";
            sql[15] = @"alter table version_info
 	                    alter column version float";
            sql[16] = @"alter table trainingtemplate
	                    add ExersizeCategoryId int CONSTRAINT FK_TrainingTemplate_ExersizeCategoryId references ExersizeCategory (Id)";
            sql[17] = @"CREATE UNIQUE NONCLUSTERED INDEX IDX_ExersizeCategoryLink_ExersizeId_ExersizeCategoryId ON ExersizeCategoryLink (ExersizeId asc, ExersizeCategoryId asc)
                    WITH (STATISTICS_NORECOMPUTE = OFF)";
            sql[18] = @"CREATE TABLE Settings
                        (
                           [Key] nvarchar(50) NOT NULL constraint PK_Settings_Key PRIMARY KEY,
                           Value nvarchar(100) not null
                        )";
            sql[19] = @"alter table TrainingTemplate
	                    DROP CONSTRAINT FK_TrainingTemplate_TemplateId";
            sql[20] = @"ALTER TABLE TrainingTemplate
                         ADD CONSTRAINT FK_TrainingTemplate_TemplateId FOREIGN KEY (TemplateId) REFERENCES Template(Id)";
            sql[21] = @"CREATE TABLE CardioTemplate
                        (
                            Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
                            TemplateId int not null CONSTRAINT FK_CardioTemplate_TemplateId references Template (Id),
                            CardioTypeId int not null constraint FK_CardioTemplate_CardioTypeId references CardioType(Id),
                            Velocity float,
                            Time float,
                            Distance float,
                            Intensivity float,
                            Resistance float,
                            HeartRate float
                        )";

        }
        public static List<string> GetListUpdates(double version)
        {
            return (from v in sql
                    where v.Key > version
                    orderby v.Key ascending
                    select v.Value).ToList();
        }
        public static List<double> GetVersionsUpdate(double version)
        {
            return (from v in sql
                    where v.Key > version
                    orderby v.Key ascending
                    select v.Key).ToList();
        }
        public static string GetSql(double version)
        {
            return sql[version];
        }
    }
}
