using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.Entity;
using DataAccessLayer.Repository;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace Service.Implementation
{
    public class CarColorService : ICarColorService
    {
        private readonly IGenericRepository<CarColor> _repository;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CarColorService(IGenericRepository<CarColor> repository, AppDbContext context, IMapper mapper)
        {
            _repository = repository;
            _context = context;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<CarColorDTO>> GetAllAsync()
        {
        }
    }

}
