﻿using Application.Common.Interfaces;
using Application.Common.Repositories.CategoryRepo;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQS.CategoryR.Commands
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, AddCategoryCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public AddCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<AddCategoryCommandResponse> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var addedCategory=_mapper.Map<Category>(request);
            var result = await _unitOfWork.CategoryWriteRepository.AddAsync(addedCategory);
            if (result)
            {
                return new AddCategoryCommandResponse { IsSuccess = true };
            }
            else return new AddCategoryCommandResponse { IsSuccess = false };
        }
    }
}
