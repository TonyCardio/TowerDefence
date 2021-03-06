﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TowerDefence.Domain;
using TowerDefence.View;

namespace TowerDefence
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
        /*
         * # Сценарии
         * 
         * Сценарий игры
         * - Показывается кнопка для начала Игры/Уровня
         * - Игрок за некоторый промежуток времени размещает турели
         * - По истечении промежутка времени начинаются волны мобов
         * - Установленные турели самостоятельно стреляют по мобам, но только в области своей досягаемости
         * - За убийство мобов Игрок получает очки, за которые может купить новые/улучшить старые турели
         * - Игра/Уровень завершается при убийстве всех мобов или при разрушении замка игрока
         * 
         * 
         * Сценарий размещения
         * - В начале каждой Игры/Уровня игроку даётся N-ая сумма денег для покупки турелей
         * - Пользователь размещает свои турели на разрешённых участках поля (нельзя ставить прямо на дорогу)
         * - Можно кликнуть по турели, чтоб её выбрать и переместить
         * - Турели должны размещаться без конфликтов (1 турель на 1 клетку поля)
         */
    }
}
