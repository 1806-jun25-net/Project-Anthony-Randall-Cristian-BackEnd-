using System;
using System.Collections.Generic;
using System.Text;
using ZVRPub.Scaffold;

namespace ZVRPub.Repository
{
    class ZVRPubRepository
    {

        private readonly ZVRContext _db;

        public ZVRPubRepository(ZVRContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

    }
}
