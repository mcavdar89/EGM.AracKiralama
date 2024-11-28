﻿using Infra.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGM.AracKiralama.Model.Dtos
{
    public class PersonelSepetDto : BaseDto
    {
        public Guid Id { get; set; }
        public int PerosenelId { get; set; }
        public string PerosenelIsim { get; set; }
        public decimal ToplamTutra { get; set; }

        public List<PersonelSepetUrunDto> PersonelSepetUrunList { get; set; }



    }
}