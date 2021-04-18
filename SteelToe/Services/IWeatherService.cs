using System.Threading.Tasks;

namespace SteelToe.Services
{
    public interface IWeatherService
    {
        Task<string> GetSettingWeather();
        Task<string> GetSettingRandomValue(string cityName);
    }
}