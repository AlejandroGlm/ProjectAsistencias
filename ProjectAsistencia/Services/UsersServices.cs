using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProjectAsistencia.Entity;

namespace ProjectAsistencia.Services
{
    public class UsersServices
    {
        private readonly HttpClient _httpClient;

        public UsersServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<Asist_Usuarios>> GetAsistenciasConNombres()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:44341/api/UsersAsist/AsistenciasConNombres");
                response.EnsureSuccessStatusCode();

                var asistencias = await response.Content.ReadFromJsonAsync<List<Asist_Usuarios>>();
                return asistencias ?? new List<Asist_Usuarios>();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las asistencias con nombres: " + ex.Message);
            }
        }

        public async Task<bool> Login(Usuarios usuarios)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:44341/api/UsersAsist/login", usuarios);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al iniciar sesión: " + ex.Message);
            }
        }

        public async Task<bool> CheckOut(int idUsuario)
        {
            try
            {
                var checkOutRequest = new { Id_Usuario = idUsuario };
                var response = await _httpClient.PostAsJsonAsync("https://localhost:44341/api/UsersAsist/CheckOut", checkOutRequest);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la hora de salida: " + ex.Message);
            }
        }

        public async Task<bool> CheckIn(int idUsuario)
        {
            try
            {
                var checkInRequest = new { Id_Usuario = idUsuario };
                var response = await _httpClient.PostAsJsonAsync("https://localhost:44341/api/UsersAsist/CheckIn", checkInRequest);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar la hora de entrada: " + ex.Message);
            }
        }

        public async Task<bool> Register(Usuarios usuario)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("https://localhost:44341/api/UsersAsist/register", usuario);
                response.EnsureSuccessStatusCode();
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al registrar el usuario: " + ex.Message);
            }
        }
    }
}
