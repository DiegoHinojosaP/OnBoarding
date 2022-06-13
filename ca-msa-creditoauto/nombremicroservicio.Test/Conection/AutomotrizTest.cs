using Microsoft.EntityFrameworkCore;
using nombremicroservicio.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace nombremicroservicio.Test.Conection
{
    public class AutomotrizTest
    {
        protected AutomotrizContext ConecciontContext(string baseDatos)
        { 
            var dbBase = new DbContextOptionsBuilder<AutomotrizContext>().UseInMemoryDatabase(baseDatos).Options;
            var dbContext = new AutomotrizContext(dbBase);
            return dbContext;
        }
    }
}
