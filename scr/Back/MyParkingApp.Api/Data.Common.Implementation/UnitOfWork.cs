using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Core.DataTransferObject;
using Data.Common.Definition;
using Microsoft.EntityFrameworkCore;

namespace Data.Common.Implementation
{
    public class UnitOfWork : DbContext, IUnitOfWork
    {
        public int CommitInt()
        {
            return SaveChanges();
        }

        public DbSet<TEntity> CreateSet<TEntity>() where TEntity : class
        {
            return Set<TEntity>();
        }

        public void RollbackChanges()
        {
            ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Unchanged);
        }

        public void AttachEntity<T>(T item) where T : class
        {
            Attach(item);
        }
        public void AddEntity<T>(T item) where T : class
        {
            this.Add(item);
        }

        public void RemoveEntity<T>(T item) where T : class
        {
            this.Remove(item);
        }

        public int ExecuteQuery(string query, List<ParameterDto> parameters, bool procedure = false)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectManagerString"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.CommandType = procedure ? CommandType.StoredProcedure : CommandType.Text;
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter.ParameterName, (SqlDbType)(int)parameter.DbType).Value = parameter.Value;
                    }
                    //cmd.Parameters.AddRange(parameters.ToArray());

                    //cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = txtFirstName.Text;
                    //cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = txtLastName.Text;
                    cmd.CommandTimeout = 0;
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}