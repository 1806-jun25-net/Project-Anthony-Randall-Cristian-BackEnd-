using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;



namespace ZVRPub.Repository
{
    public class IdentityRepo
    {
        private readonly IdentityDbContext _db;

        public IdentityRepo(IdentityDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }
    }
}
