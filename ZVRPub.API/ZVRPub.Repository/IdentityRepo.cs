using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;



namespace ZVRPub.Repository
{
    public class IdentityRepo
    {
        private readonly IdentityDbContext _db;

        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public IdentityRepo(IdentityDbContext db)
        {
            log.Info("Creating instance of Identity repository");
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
    }
}
