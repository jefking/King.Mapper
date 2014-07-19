namespace King.Mapper.Integration.Model
{
    using King.Mapper.Generated.Sql;
    using System;

    public class SimulatedSelectStatement : dboSimulatedSelectStatement
    {
        public static SimulatedSelectStatement Create()
        {
            var random = new Random();
            var data = new SimulatedSelectStatement()
            {
                TestInt = random.Next(),
                TestBigInt = random.Next(),
                TestBit = true,
                TestChar = 'x',
                TestDate = DateTime.UtcNow,
                TestDateTime = DateTime.UtcNow,
                TestDateTime2 = DateTime.UtcNow,
                TestDecimal = Convert.ToDecimal(random.NextDouble()),
                TestFloat = Convert.ToSingle(random.NextDouble()),
                TestMoney = Convert.ToDecimal(random.NextDouble()),
                TestNChar = 'y',
                TestNText = Guid.NewGuid().ToString(),
                TestText = Guid.NewGuid().ToString(),
                TestGuid = Guid.NewGuid(),
            };

            data.TestBinary = new byte[64];
            random.NextBytes(data.TestBinary);

            data.TestImage = new byte[64];
            random.NextBytes(data.TestImage);

            return data;
        }
    }
}
