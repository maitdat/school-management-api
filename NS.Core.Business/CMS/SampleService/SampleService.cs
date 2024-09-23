using Microsoft.EntityFrameworkCore.Storage;
using NS.Core.Commons;
using NS.Core.Models;
using NS.Core.Models.Entities;
using NS.Core.Models.RequestModels;
using NS.Core.Models.ResponseModels;
using System.Text;
using static NS.Core.Commons.Enums;

namespace NS.Core.Business.SampleService
{
    public class SampleService : ISampleService
    {
        private readonly AppDbContext _dbContext;

        public SampleService(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Task<BasePaginationResponseModel<SampleData>> GetAll(SampleRequestModel input)
        {
            var data = new SampleData().GetSampleDatas(input.ItemCount);

            if (!string.IsNullOrEmpty(input.Keyword.Trim()))
            {
                data = data.Where(item => item.FullName.ToLower().Contains(input.Keyword.Trim()));
            }

            if (input.Status is not null && input.Status.Count > 0)
            {
                data = data.Where(item => input.Status.Contains(item.Status));
            }
            var result = data.ApplyPaging(input.PageNo, input.PageSize, out var totalItems).ToList();
            return Task.FromResult(new BasePaginationResponseModel<SampleData>(input.PageNo, input.PageSize, result, totalItems));
        }
    }
    public class SampleData
    {
        public string FullName { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int IntField { get; set; }
        public decimal DecimalField { get; set; }
        public DateOnly DateField { get; set; }
        public DateTime DateTimeField { get; set; }

        private Random Random { get { return new Random(); } }
        private string GenerateString(int wordCount)
        {
            const string CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ";
            const int MIN_CHARACTER_COUNT = 2;
            const int MAX_CHARACTER_COUNT = 5;

            var sb = new StringBuilder();
            for (int i = 0; i < wordCount; i++)
            {
                sb.Append(new string(Enumerable.Repeat(CHARACTERS, Random.Next(MIN_CHARACTER_COUNT, MAX_CHARACTER_COUNT))
                .Select(s => s[Random.Next(s.Length)]).ToArray()));
                sb.Append(CHARACTERS.ToCharArray().Last());
            }
            return sb.ToString().Trim();
        }

        private int GenerateInt(int min = 0, int max = 99999)
        {
            return Random.Next(min, max);
        }

        private decimal GenerateDecimal()
        {
            const int MULTIPLER = 10000000;
            return (decimal)Random.NextDouble() * MULTIPLER;
        }

        private DateTime GenerateDateTime()
        {
            const int DAY_ADD = 100;
            const int SECOND_ADD = 10000;
            return DateTime.Now
                .AddDays(Random.NextInt64(-DAY_ADD, DAY_ADD))
                .AddSeconds(Random.NextInt64(-SECOND_ADD, SECOND_ADD));
        }

        private DateOnly GenerateDate()
        {
            return DateOnly.FromDateTime(GenerateDateTime());
        }

        public IQueryable<SampleData> GetSampleDatas(int totalRecord)
        {
            var result = new List<SampleData>();
            const int MIN_NAME_WORD_COUNT = 2;
            const int MAX_WORD_CHARACTER_COUNT = 3;
            const int MIN_WORD_COUNT = 20;
            const int MAX_WORD_COUNT = 30;
            const int MIN_STATUS_NUMBER = 1;
            const int MAX_STATUS_NUMBER = 5;
            for (int i = 0; i < totalRecord; i++)
            {
                result.Add(new SampleData
                {
                    FullName = GenerateString(Random.Next(MIN_NAME_WORD_COUNT, MAX_WORD_CHARACTER_COUNT)),
                    Description = GenerateString(Random.Next(MIN_WORD_COUNT, MAX_WORD_COUNT)),
                    Status = Random.Next(MIN_STATUS_NUMBER, MAX_STATUS_NUMBER),
                    IntField = GenerateInt(),
                    DecimalField = GenerateDecimal(),
                    DateField = GenerateDate(),
                    DateTimeField = GenerateDateTime(),
                });
            }
            return result.AsQueryable();
        }
    }

}
