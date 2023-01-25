using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ivegaS7
{
    public interface dataBase
    {
        SQLiteAsyncConnection GetConnection();
    }
}
