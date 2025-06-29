using Microsoft.AspNetCore.Mvc;

namespace Fedorova.UI.Models
{
    public class ListModel<T> : List<T>
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        private ListModel(IEnumerable<T> items,
        int total,
        int current) : base(items)
        {
            TotalPages = total;
            CurrentPage = current;
        }
        /// <summary>
        /// Получить модель представления списка объектов
        /// </summary>
        /// <param name="list">исходный список объектов</param>
        /// <param name="current">номер текущей страницы</param>
        /// <param name="itemsPerPage">кол. объектов на странице</param>
        /// <returns>объект класса ListViewModel</returns>
        public static ListModel<T> GetModel(IEnumerable<T> list, int current, int itemsPerPage)
        {
            var items = list
            .Skip((current - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToList();
            var total = (int)Math.Ceiling((double)list.Count()/itemsPerPage);
            return new ListModel<T>(items, total, current);
        }
    }
}
