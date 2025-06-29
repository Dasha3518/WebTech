using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fedorova.Domain.Entities
{
    public class Dish
    {
        //public int Id { get; set; } // id блюда
        //public string Name { get; set; } // название блюда
        //public string Description { get; set; } // описание блюда
        //public int Calories { get; set; } // кол. калорий на порцию
        //public string NormalizedName { get; set; } // кол. калорий на порцию
        //public string Image { get; set; } // имя файла изображения
        //                                  // Навигационные свойства
        ///// <summary>
        ///// группа блюд (например, супы, напитки и т.д.)
        ///// </summary>
        //public int DishGroupId { get; set; }
        //public DishGroup Group { get; set; }

        public int Id { get; set; } // id блюда
        public string Name { get; set; } // название блюда
        public string Description { get; set; } // описание блюда
        public int Calories { get; set; } // кол. калорий на порцию
        public string Image { get; set; } // путь к файлу изображения
                                           // Навигационные свойства
        /// <summary>
        /// группа блюд (например, супы, напитки и т.д.)
        /// </summary>
        public int CategoryId { get; set; }
        
        public Category Category { get; set; }

    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
    }
}
