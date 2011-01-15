using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace TrainingCatalog.BusinessLogic
{
    public class TrainingBusiness
    {
        public static int GetTrainingDayId(DateTime date, SqlCeCommand cmd)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "select ID from Training where Day = @date";
            cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date.Date;

            object o = cmd.ExecuteScalar();
            if (o == null || o is DBNull)
            {
                cmd.Parameters.Clear();
                // создаем новый тренировочный день
                cmd.CommandText = "insert into Training (Day, Comment, BodyWeight) values(@date,@comment, @bodyWeight)";
                cmd.Parameters.Add("@date", SqlDbType.DateTime).Value = date.Date;
                cmd.Parameters.Add("@comment", SqlDbType.NVarChar).Value = string.Empty;
                cmd.Parameters.Add("@bodyWeight", SqlDbType.Float).Value = 0;
                cmd.ExecuteNonQuery();

                cmd.Parameters.Clear();
                cmd.CommandText = "Select @@Identity";
                o = cmd.ExecuteScalar();
            }
            return Convert.ToInt32(o);
        }

        internal static void AddExersize(SqlCeCommand cmd, int TrainingId, int ExersizeId, int weight, int count)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = String.Format("insert into Link (TrainingId, ExersizeId, Weight,[Count]) values({0},{1},{2},{3})", TrainingId, ExersizeId, weight, count);
            cmd.ExecuteNonQuery();
        }
    }
}
