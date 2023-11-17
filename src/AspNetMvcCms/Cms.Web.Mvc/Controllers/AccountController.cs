using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Cms.Web.Models.Dto;

public class AccountController : Controller
{
	private readonly IConfiguration _configuration;
	private readonly HttpClient _apiClient;

	public AccountController(IConfiguration configuration, IHttpClientFactory httpClientFactory)
	{
		_configuration = configuration;
		_apiClient = httpClientFactory.CreateClient();
		_apiClient.BaseAddress = new Uri("https://localhost:7134"); // API'nizin doğru adresini buraya ekleyin
	}

	public IActionResult Login()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Login(Cms.Web.Models.Dto.LoginDto model)
	{
		if (ModelState.IsValid)
		{
			// Kullanıcı girişi için API'yi çağır
			var response = await _apiClient.PostAsJsonAsync("api/auth/login", model);

			if (response.IsSuccessStatusCode)
			{
				// API'den gelen token
				var token = await response.Content.ReadFromJsonAsync<LoginDto>();

				// Token'i kullanarak işlemler yapabilirsiniz

				return RedirectToAction("Index", "Home"); // veya başka bir sayfaya yönlendirme
			}
			else
			{
				// API'den hata döndü
				ModelState.AddModelError("", "Invalid email or password");
			}
		}

		return View(model);
	}

	[HttpGet]
	public IActionResult Register()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(Cms.Web.Models.Dto.RegisterDto model)
	{
		if (ModelState.IsValid)
		{
			// Kullanıcı kaydı için API'yi çağır
			var response = await _apiClient.PostAsJsonAsync("api/auth/register", model);

			if (response.IsSuccessStatusCode)
			{
				// Başarılı ise bir işlem yapabilirsiniz, örneğin kullanıcıyı başka bir sayfaya yönlendirme
				return RedirectToAction("Index", "Home");
			}
			else
			{
				// API'den hata döndü
				ModelState.AddModelError("", "Registration failed");
			}
		}

		return View(model);
	}
	[HttpGet]
	public IActionResult ForgotPassword()
	{
		return View();
	}
}
