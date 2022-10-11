using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiEcommerceDDD.Application.Dtos
{
    public class PaginationDto<T>
    {
        public int CurrentPage { get; set; } = 0;

        public int TotalItems { get; set; } = 0;

        public int TotalPages { get; set; } = 0;

        public IEnumerable<T> Items { get; set; }

        public PaginationDto(IEnumerable<T> items, int totalItems, int page, int limit)
        {
            Items = items;
            TotalItems = totalItems;
            TotalPages = 0;

            if (items != null && items.Count() > 0 && totalItems > 0)
            {
                if (limit > 0)
                    TotalPages = (int)Math.Ceiling(totalItems / (double)limit);
                else
                    TotalPages = 1;

                CurrentPage = page > 0 ? page : 1;
            }
        }
    }
}