using AutoMapper;
using CleanArch.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Dtos
{
	public class AutommaperProfille : Profile
	{
		public AutommaperProfille()
		{
			CreateMap<Contact, ContactDto>();
			CreateMap<ContactDto, Contact>();
		}
	}
}
