﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingCatalog.AppResources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class SqlUpdate {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlUpdate() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TrainingCatalog.AppResources.SqlUpdate", typeof(SqlUpdate).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Create table BodyMeasurement (
        ///	Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
        ///    TrainingId int not null CONSTRAINT FK_BodyMeasurement_TrainingId references Training (Id),
        ///	Waistline_h float constraint DF_Waistline_h default(0),
        ///	Waistline_l float constraint DF_Waistline_l default(0),
        ///	Biceps_h float constraint DF_Biceps_h default(0),
        ///	Biceps_l float constraint DF_Biceps_l default(0),
        ///	Chest_h float constraint DF_Chest_h default(0),
        ///	Chest_l float constraint DF_Chest_l defaul [rest of string was truncated]&quot;;.
        /// </summary>
        public static string v10 {
            get {
                return ResourceManager.GetString("v10", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE UNIQUE NONCLUSTERED INDEX IDX_BodyMeasurement_TrainingId ON BodyMeasurement (TrainingId DESC)
        ///WITH (STATISTICS_NORECOMPUTE = OFF).
        /// </summary>
        public static string v11 {
            get {
                return ResourceManager.GetString("v11", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE CardioType
        ///(
        ///   Id int NOT NULL identity(1,1) constraint PK_CardioType_Id PRIMARY KEY,
        ///   Name nvarchar(100) not null,
        ///   Velocity bit not null,
        ///   Time bit not null,
        ///   Distance bit not null, 
        ///   Intensivity bit not null CONSTRAINT DF_CardioType_Intensivity default (1),    
        ///   Resistance bit not null,
        ///   HeartRate bit not null
        ///).
        /// </summary>
        public static string v12_1 {
            get {
                return ResourceManager.GetString("v12_1", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE CardioSession
        ///(
        ///   Id int NOT NULL identity(1,1) constraint PK_CardioSession_Id PRIMARY KEY,
        ///   TrainingId int not null CONSTRAINT FK_CardioSession_TrainingId references Training (Id),
        ///   StartTime int,
        ///   EndTime int
        ///).
        /// </summary>
        public static string v13 {
            get {
                return ResourceManager.GetString("v13", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE CardioInterval
        ///(
        ///   Id int NOT NULL identity(1,1) constraint PK_CardioSession_Id PRIMARY KEY,
        ///   CardioSessionId int not null CONSTRAINT FK_CardioInterval_CardioSessionId references CardioSession (Id),   CardioTypeId int not null constraint FK_CardioSession_CardioTypeId references CardioType (Id),
        ///   Velocity float ,
        ///   Time float,
        ///   Distance float,
        ///   Intensivity float,
        ///   Resistance float,
        ///   HeartRate float
        ///).
        /// </summary>
        public static string v14 {
            get {
                return ResourceManager.GetString("v14", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to alter table version_info
        /// 	alter column version float.
        /// </summary>
        public static string v15 {
            get {
                return ResourceManager.GetString("v15", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to alter table trainingtemplate
        ///	add ExersizeCategoryId int CONSTRAINT FK_TrainingTemplate_ExersizeCategoryId references ExersizeCategory (Id).
        /// </summary>
        public static string v16 {
            get {
                return ResourceManager.GetString("v16", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE UNIQUE NONCLUSTERED INDEX IDX_ExersizeCategoryLink_ExersizeId_ExersizeCategoryId ON ExersizeCategoryLink (ExersizeId asc, ExersizeCategoryId asc)
        ///WITH (STATISTICS_NORECOMPUTE = OFF).
        /// </summary>
        public static string v17 {
            get {
                return ResourceManager.GetString("v17", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE Settings
        ///(
        ///   [Key] nvarchar(50) NOT NULL constraint PK_Settings_Key PRIMARY KEY,
        ///   Value nvarchar(100) not null
        ///).
        /// </summary>
        public static string v18 {
            get {
                return ResourceManager.GetString("v18", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to alter table TrainingTemplate
        ///	DROP CONSTRAINT FK_TrainingTemplate_TemplateId.
        /// </summary>
        public static string v19 {
            get {
                return ResourceManager.GetString("v19", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ALTER TABLE TrainingTemplate
        ///    ADD CONSTRAINT FK_TrainingTemplate_TemplateId FOREIGN KEY (TemplateId) REFERENCES
        ///    Template(Id).
        /// </summary>
        public static string v20 {
            get {
                return ResourceManager.GetString("v20", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE CardioTemplate
        ///(
        ///   Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
        ///   TemplateId int not null CONSTRAINT FK_CardioTemplate_TemplateId references Template (Id),
        ///   CardioTypeId int not null constraint FK_CardioTemplate_CardioTypeId references CardioType(Id),
        ///   Velocity float,
        ///   Time float,
        ///   Distance float,
        ///   Intensivity float,
        ///   Resistance float,
        ///   HeartRate float
        ///).
        /// </summary>
        public static string v21 {
            get {
                return ResourceManager.GetString("v21", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Alter table BodyMeasurement add Muscule float constraint DF_BodyFat default(0).
        /// </summary>
        public static string v22 {
            get {
                return ResourceManager.GetString("v22", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE Training
        ///(
        ///   Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
        ///   Day datetime not null CONSTRAINT IX_Training_Day UNIQUE,
        ///   Comment nvarchar(1000) NOT NULL default &apos;&apos;,
        ///   BodyWeight float null
        ///).
        /// </summary>
        public static string v3 {
            get {
                return ResourceManager.GetString("v3", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE Exersize
        ///(
        ///   Id int NOT NULL identity(1,1) constraint PK_Exersize_Id PRIMARY KEY,
        ///   ShortName nvarchar(100) not null default &apos;&apos;,
        ///   Description nvarchar(2000) NOT NULL default &apos;&apos;,
        ///   Img Image null
        ///).
        /// </summary>
        public static string v4 {
            get {
                return ResourceManager.GetString("v4", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE Link
        ///(
        ///   Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
        ///   TrainingId int not null CONSTRAINT FK_Link_TrainingId references Training (Id),
        ///   ExersizeId int NOT NULL Constraint FK_Link_ExersizeId references Exersize (Id),
        ///   Weight int not null,
        ///   [Count] int not null
        ///
        ///).
        /// </summary>
        public static string v5 {
            get {
                return ResourceManager.GetString("v5", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE ExersizeCategory
        ///(
        ///   Id int NOT NULL identity(1,1) constraint PK_ExersizeCategoryLink_Id PRIMARY KEY,
        ///   Name nvarchar(100) not null
        ///).
        /// </summary>
        public static string v6 {
            get {
                return ResourceManager.GetString("v6", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Верхняя часть спины&apos;).
        /// </summary>
        public static string v6_01 {
            get {
                return ResourceManager.GetString("v6_01", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Средняя часть спины&apos;).
        /// </summary>
        public static string v6_02 {
            get {
                return ResourceManager.GetString("v6_02", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Нижняя часть спины&apos;).
        /// </summary>
        public static string v6_03 {
            get {
                return ResourceManager.GetString("v6_03", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Спина&apos;).
        /// </summary>
        public static string v6_04 {
            get {
                return ResourceManager.GetString("v6_04", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Плечи&apos;).
        /// </summary>
        public static string v6_05 {
            get {
                return ResourceManager.GetString("v6_05", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Ноги&apos;).
        /// </summary>
        public static string v6_06 {
            get {
                return ResourceManager.GetString("v6_06", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Пресс&apos;).
        /// </summary>
        public static string v6_07 {
            get {
                return ResourceManager.GetString("v6_07", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Икры&apos;).
        /// </summary>
        public static string v6_08 {
            get {
                return ResourceManager.GetString("v6_08", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Грудь&apos;).
        /// </summary>
        public static string v6_09 {
            get {
                return ResourceManager.GetString("v6_09", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Бицепц&apos;).
        /// </summary>
        public static string v6_10 {
            get {
                return ResourceManager.GetString("v6_10", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Трицепц&apos;).
        /// </summary>
        public static string v6_11 {
            get {
                return ResourceManager.GetString("v6_11", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Предплечья&apos;).
        /// </summary>
        public static string v6_12 {
            get {
                return ResourceManager.GetString("v6_12", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to insert into exersizecategory (Name) values(&apos;Руки&apos;).
        /// </summary>
        public static string v6_13 {
            get {
                return ResourceManager.GetString("v6_13", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE ExersizeCategoryLink
        ///(
        ///   Id int NOT NULL identity(1,1) constraint PK_ExersizeCategoryLink_Id PRIMARY KEY,
        ///   ExersizeId int not null CONSTRAINT FK_ExersizeCategoryLink_ExersizeId references Exersize (id),
        ///   ExersizeCategoryId int not null constraint FK_ExersizeCategoryLink_ExersizeCategoryId references ExersizeCategory (id)
        ///).
        /// </summary>
        public static string v7 {
            get {
                return ResourceManager.GetString("v7", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE TrainingTemplate
        ///(
        ///   Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
        ///   TemplateId int not null CONSTRAINT FK_TrainingTemplate_TemplateId references Training (Id),
        ///   ExersizeId int NOT NULL Constraint FK_TrainingTemplate_ExersizeId references Exersize (Id),
        ///   Weight int not null,
        ///   [Count] int not null
        ///).
        /// </summary>
        public static string v8 {
            get {
                return ResourceManager.GetString("v8", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE TABLE Template
        ///(
        ///   Id int NOT NULL identity(1,1) constraint PK_Training_Id PRIMARY KEY,
        ///   Name nvarchar(100) not null 
        ///).
        /// </summary>
        public static string v9 {
            get {
                return ResourceManager.GetString("v9", resourceCulture);
            }
        }
    }
}
