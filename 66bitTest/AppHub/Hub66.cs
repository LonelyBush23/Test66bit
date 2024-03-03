using _66bitTest.Models;
using _66bitTest.Models.DB;
using _66bitTest.ModelsViews;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Reflection;

namespace _66bitTest.AppHub
{
    public class Hub66 : Hub
    {
        private readonly AppDbContext _context;

        public Hub66(AppDbContext context)
        {
            _context = context;
        }

        public async Task Send()
        {
            var products = await _context.Human.ToListAsync();
            var result = products.Select(person => new HumanView
            {
                Id = person.Id,
                BirthDate = person.BirthDate,
                Country = person.Country,
                FirstName = person.FirstName,
                Gender = person.Gender,
                SecondName = person.SecondName,
                TeamName = person.Team.Title
            }).ToList();
            //foreach (var person in products)
            //{
            //    _context.Entry(person).Reload();
            //}

            await Clients.All.SendAsync("ReceivedProducts", result);
        }
    }
}
