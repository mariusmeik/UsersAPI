using Core.Contracts;
using Core.Entities;
using Npgsql;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly NpgsqlConnection _connection;

        public UserRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }


        //public async Task Save(List<UserEntity> users)
        //{
        //    var query = @"SELECT id, status, created_at as CreatedAt, last_action_at as LastActionAt FROM refresh_state
        //              WHERE status = @notStartedState OR status = @runningState";

        //    return await _connection.QueryFirstOrDefaultAsync<UserEntity>(query, new
        //    {
        //        id,

        //        name
        //    });
        //}
        //public async Task UpsertCurrencyRates(List<CurrencyExchangeRate> rates)
        //{

        //    var query = @"UPDATE exchange_rate
        //               SET rate=@rate, currency=@currency, last_refreshed=@date
        //               WHERE DATE(last_refreshed)=DATE(@date) and currency=@currency;
        //               INSERT INTO exchange_rate(currency, rate, last_refreshed)      
        //               SELECT @currency, @rate, @date    
        //               WHERE NOT EXISTS (SELECT * FROM exchange_rate WHERE DATE(last_refreshed)=DATE(@date) and currency=@currency);";

        //    foreach (var rate in rates)
        //    {
        //        await _connection.ExecuteAsync(query, new
        //        {
        //            rate = rate.Rate,
        //            date = rate.LastRefreshed,
        //            currency = rate.Currency
        //        });
        //    }
        //}
        //public async Task<RefreshState> GetById(Guid id)
        //{
        //    var query = @"SELECT id, status, created_at as CreatedAt, last_action_at as LastActionAt FROM refresh_state 
        //              WHERE id = @id";

        //    return await _connection.QueryFirstOrDefaultAsync<RefreshState>(query, new
        //    {
        //        id
        //    });
        //}
    }
}
