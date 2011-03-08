﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
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
    internal class SqlUpdate {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal SqlUpdate() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
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
        internal static global::System.Globalization.CultureInfo Culture {
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
        internal static string v10 {
            get {
                return ResourceManager.GetString("v10", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CREATE UNIQUE NONCLUSTERED INDEX IDX_BodyMeasurement_TrainingId ON BodyMeasurement (TrainingId DESC)
        ///WITH (STATISTICS_NORECOMPUTE = OFF).
        /// </summary>
        internal static string v11 {
            get {
                return ResourceManager.GetString("v11", resourceCulture);
            }
        }
    }
}
