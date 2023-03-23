using BikeRepairShop.BL.Domain;
using BikeRepairShop.DL.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeRepairShop.DL.Repositories
{
    public class RepairOrderRepository
    {
        private string connectionString;

        public RepairOrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        private void AddRepairTask(int repairId,RepairTask repairTask, SqlCommand command)
        {
            string sql = "";
            command.CommandText = sql;
            command.Parameters.Clear();
            //parameters
            int rtid=(int)command.ExecuteScalar();
            repairTask.SetId(rtid);
        }
        private void AddRepair(int repairOrderId,Repair repair, SqlCommand command)
        {
            string sql = "";
            command.CommandText = sql;
            command.Parameters.Clear();
            //paramaters toevoegen
            int rid=(int)command.ExecuteScalar();
            repair.SetId(rid);
            foreach(RepairTask rt in repair.RepairTasks())
            {
                AddRepairTask(rid,rt,command);
            }
        }
        public void AddRepairOrder(RepairOrder repairOrder)
        {
            try
            {
                string sqlRO = "INSERT INTO repairorder(payed,urgency,datein,dateout,customerid,discount,cost,status) output INSERTED.ID VALUES(@payed,@urgency,@datein,@dateout,@customerid,@discount,@cost,@status)";
                using(SqlConnection connection= new SqlConnection(connectionString))
                using(SqlCommand command= connection.CreateCommand())
                {
                    connection.Open();
                    SqlTransaction transaction= connection.BeginTransaction();
                    try
                    {
                        command.Transaction= transaction;
                        command.CommandText= sqlRO;
                        //parameters
                        int id=(int)command.ExecuteScalar();
                        repairOrder.SetId(id);
                        foreach(Repair r in repairOrder.Repairs())
                        {
                            AddRepair(id, r, command);
                        }
                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new RepairOrderRepositoryException("addrepairorder", ex);
            }
        }
    }
}
