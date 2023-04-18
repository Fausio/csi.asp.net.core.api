﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csi.asp.net.core.model.helper.paginatin
{
    public class PagingParameterModel
    {
        const int maxPageSize = 20;

        public int pageNumber { get; set; } = 1;

        public int _pageSize { get; set; } = 10;

        public int pageSize
        {

            get { return _pageSize; }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }