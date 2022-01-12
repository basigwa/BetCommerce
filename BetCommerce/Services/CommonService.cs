using AutoMapper;
using BetCommerce.Entities.Common;
using BetCommerce.Helpers;
using BetCommerce.RepositoryMixin;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetCommerce.Services
{
    public class CommonService : Repository, ICommonService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;
        public CommonService(
            DataContext context,
            IMapper mapper,
            IOptions<AppSettings> appSettings) : base(context)
        {
            _context = context;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }
        public async Task<(string, CodeGenerator)> GenerateCode(object[] args)
        {
            var codequery = await FirstOrDefaultOptimisedAsync<CodeGenerator>("select * from codegenerators where numbercategory={0}", args);
            int _no = codequery.CurrentNumber + codequery.Seed;
            codequery.CurrentNumber = _no;
            args[1] = _no;
            string updatecodequery = @"update codegenerators set CurrentNumber={1} where numbercategory={0}";
            await UpdateAsync(updatecodequery, args);
            return ($"{codequery.Prefix}{_no.ToString().PadLeft(codequery.CharacterCount, '0')}", codequery);
        }
    }
}
