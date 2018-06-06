using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlightManager.DataAccessLayer;
using FlightManager.DataAccessLayer.Entities;
using FlightManager.DataAccessLayer.Repositories;
using AutoMapper;
using FlightManager.Models;
using AutoMapper.QueryableExtensions;
using FlightManager.Helpers;

namespace FlightManager.Controllers
{
    public class FlightController : Controller
    {
        private IFlightRepository _flightRepository;
        private IAirportRepository _airportRepository;
        private IAirlineRepository _airlineRepository;
        private IMapper _mapper;
        private IQueryable<Airport> airports;
        private IQueryable<Airline> airlines;

        public FlightController(IFlightRepository flightRepository, IAirportRepository airportRepository, IAirlineRepository airlineRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _airportRepository = airportRepository;
            _airlineRepository = airlineRepository;
            _mapper = mapper;
            airports = _airportRepository.GetAllAirports();
            airlines = _airlineRepository.GetAllAirlinesCompanies();
        }

        public IActionResult Index()
        {
            IQueryable<Flight> flights = _flightRepository.GetAllFlights();
            return View(flights.ProjectTo<FlightViewModel>());
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _flightRepository.GetFlightById((int)id);

            if (flight == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<FlightViewModel>(flight));
        }

        public IActionResult Create()
        {

            FlightViewModel flightViewModel = new FlightViewModel()
            {
                AllAirlineCompanies = airlines.ProjectTo<AirlineViewModel>(),
                AllAirports = airports.ProjectTo<AirportViewModel>(),

            };


            return View(flightViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlightViewModel flightViewModel)
        {
            if (ModelState.IsValid)
            {
                await _flightRepository.Create(_mapper.Map<Flight>(flightViewModel));
                return RedirectToAction(nameof(Index));
            }
            flightViewModel.AllAirlineCompanies = airlines.ProjectTo<AirlineViewModel>();
            flightViewModel.AllAirports = airports.ProjectTo<AirportViewModel>();
            return View(flightViewModel);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _flightRepository.GetFlightById((int)id);
            if (flight == null)
            {
                return NotFound();
            }
            FlightViewModel flightViewModel = _mapper.Map<FlightViewModel>(flight);
            flightViewModel.AllAirlineCompanies = airlines.ProjectTo<AirlineViewModel>();
            flightViewModel.AllAirports = airports.ProjectTo<AirportViewModel>();
            return View(flightViewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FlightViewModel flightViewModel)
        {
            if (id != flightViewModel.FlightId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _flightRepository.Update(_mapper.Map<Flight>(flightViewModel));

                return RedirectToAction(nameof(Index));
            }
            flightViewModel.AllAirlineCompanies = airlines.ProjectTo<AirlineViewModel>();
            flightViewModel.AllAirports = airports.ProjectTo<AirportViewModel>();
            return View(flightViewModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flight = await _flightRepository.GetFlightById((int)id);
            if (flight == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<FlightViewModel>(flight));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _flightRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Report()
        {
            IQueryable<Flight> flights = _flightRepository.GetAllFlights();
            return View(BusinessHelper.CalculateData(flights.ProjectTo<FlightViewModel>()));
        }
    }
}
