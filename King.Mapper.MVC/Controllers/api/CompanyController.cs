namespace King.Mapper.MVC.Controllers.api
{
    using King.Mapper.Data;
    using King.Mapper.Generated.Sql;
    using King.Mapper.MVC.Models;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using System.Web.Http;

    public class CompanyController : ApiController
    {
        private readonly IExecutor executor;

        public CompanyController()
        {
            var config = ConfigurationManager.AppSettings.Map<ConfigurationModel>();
            var connection = new SqlConnection(config.ConnectionString);
            this.executor = new Executor(connection);
        }

        // GET: api/Company?name=
        public async Task<IEnumerable<Company>> Get(string name = null)
        {
            var sproc = new dboSearchCompanies()
            {
                NameLike = name,
            };

            var data = await this.executor.Query(sproc);
            return data.Models<Company>();
        }

        // GET: api/Company/5
        public async Task<Company> Get(int id)
        {
            var sproc = new dboSelectCompany()
            {
                Id = id,
            };

            var data = await this.executor.Query(sproc);
            return data.Model<Company>();
        }

        // POST: api/Company
        public async Task Post([FromBody] Company value)
        {
            var sproc = value.Map<dboSaveCompany>();
            await this.executor.NonQuery(sproc);
        }

        // PUT: api/Company/5
        public async Task Put(int id, [FromBody] Company value)
        {
            var sproc = value.Map<dboSaveCompany>();
            sproc.Id = id;
            await this.executor.NonQuery(sproc);
        }

        // DELETE: api/Company/5
        public async Task Delete(int id)
        {
            var sproc = new dboSaveCompany()
            {
                Delete = true,
                Id = id,
            };

            await this.executor.NonQuery(sproc);
        }
    }
}