using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietTravel.DBModels;

namespace VietTravel
{
    public partial class VietTravelDBContext : DbContext
    {
        public virtual DbSet<ACCOUNT> ACCOUNTs { get; set; }
        public virtual DbSet<APPRECIATION> APPRECIATIONs { get; set; }
        public virtual DbSet<ARTICLE> ARTICLEs { get; set; }
        public virtual DbSet<CITY> CITies { get; set; }
        public virtual DbSet<ICON> ICONs { get; set; }
        public virtual DbSet<IMAGE> IMAGES { get; set; }
        public virtual DbSet<LOCATION_TYPE> LOCATION_TYPE { get; set; }
        public virtual DbSet<LOCATION> LOCATIONS { get; set; }
        public virtual DbSet<MAP> MAPs { get; set; }
        public virtual DbSet<PLAN_TRIP> PLAN_TRIP { get; set; }
        public virtual DbSet<PROVINCE> PROVINCEs { get; set; }
        public virtual DbSet<REGION> REGIONs { get; set; }
        public virtual DbSet<SCHEDULE_TEMPLATE> SCHEDULE_TEMPLATE { get; set; }
        public virtual DbSet<TRANSPORTATION> TRANSPORTATIONs { get; set; }
        public virtual DbSet<USER> USERS { get; set; }
        public virtual DbSet<VIDEO> VIDEOs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=DBTravel6.db");
        }
    }
}
