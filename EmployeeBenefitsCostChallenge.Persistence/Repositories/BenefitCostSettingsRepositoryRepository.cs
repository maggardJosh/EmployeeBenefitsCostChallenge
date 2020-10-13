using System;
using System.Linq;
using EmployeeBenefitsCostChallenge.Domain.Common;
using EmployeeBenefitsCostChallenge.Persistence.Repositories;
using Microsoft.Extensions.Logging;

namespace EmployeeBenefitsCostChallenge.Persistence
{
    public class BenefitCostSettingsRepositoryRepository : IBenefitCostSettingsRepository
    {
        private readonly DatabaseContext _dbContext;
        private readonly ILogger<BenefitCostSettingsRepositoryRepository> _logger;
        private readonly DefaultLocalBenefitCostSettingsRepository _defaultBenefitCostSettingsRepository = new DefaultLocalBenefitCostSettingsRepository();

        public BenefitCostSettingsRepositoryRepository(DatabaseContext dbContext, ILogger<BenefitCostSettingsRepositoryRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public decimal ANameDiscountPercent
        {
            get
            {
                try
                {
                    return RetrieveDecimalApplicationSetting("ANameDiscountPercent");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    return _defaultBenefitCostSettingsRepository.ANameDiscountPercent;
                }
            }
        }



        public int NumberOfPaychecksPerYear
        {
            get
            {
                try
                {
                    return RetrieveIntegerApplicationSetting(nameof(NumberOfPaychecksPerYear));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    return _defaultBenefitCostSettingsRepository.NumberOfPaychecksPerYear;
                }
            }
        }

        public decimal StandardAnnualBenefitCost
        {
            get {
                try
                {
                    return RetrieveDecimalApplicationSetting(nameof(StandardAnnualBenefitCost));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    return _defaultBenefitCostSettingsRepository.NumberOfPaychecksPerYear;
                }
            }
        }

        public decimal DependentAnnualBenefitCost
        {
            get
            {
                try
                {
                    return RetrieveDecimalApplicationSetting(nameof(DependentAnnualBenefitCost));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                    return _defaultBenefitCostSettingsRepository.ANameDiscountPercent;
                }
            }
        }

        //TODO: Ideally would find solution using generics to remove duplicate code
        private decimal RetrieveDecimalApplicationSetting(string settingName)
        {
            var result = _dbContext.ApplicationSettings
                .FirstOrDefault(setting => setting.Name == settingName)?.Value;

            if (result == null)
                throw new Exception("Missing Application Setting for " + settingName);

            if (!decimal.TryParse(result, out decimal parsedValue))
                throw new Exception(
                    $"Application Setting for {settingName} configured incorrectly");

            return parsedValue;
        }

        private int RetrieveIntegerApplicationSetting(string settingName)
        {
            var result = _dbContext.ApplicationSettings
                .FirstOrDefault(setting => setting.Name == settingName)?.Value;

            if (result == null)
                throw new Exception("Missing Application Setting for " + settingName);

            if (int.TryParse(result, out int parsedValue))
                throw new Exception(
                    $"Application Setting for {settingName} configured incorrectly");

            return parsedValue;
        }
    }
}