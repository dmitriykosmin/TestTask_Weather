﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask_Weather.Models.WeatherResponseModels;

namespace TestTask_Weather.ViewModels
{
    public class WeatherTodayPartViewModel
    {
        private Part weatherPart;

        public string Pressure_MM
        {
            get
            {
                return $"Давление: {weatherPart.pressure_mm} мм рт. ст.";
            }
        }

        public string Wind
        {
            get
            {
                string wind;
                switch (weatherPart.wind_dir)
                {
                    case "nw":
                        wind = "северо-западный,";
                        break;
                    case "n":
                        wind = "северный,";
                        break;
                    case "ne":
                        wind = "северо-восточный,";
                        break;
                    case "e":
                        wind = "восточный,";
                        break;
                    case "se":
                        wind = "юго-восточный,";
                        break;
                    case "s":
                        wind = "южный,";
                        break;
                    case "sw":
                        wind = "юго-западный,";
                        break;
                    case "w":
                        wind = "западный,";
                        break;
                    case "с":
                        wind = "штиль,";
                        break;
                    default:
                        wind = "";
                        break;
                }
                return $"Ветер: {wind} {weatherPart.wind_speed} м/с " +
                    $"({weatherPart.wind_speed * 3.6} км/ч)";
            }
        }

        public string Humidity
        {
            get
            {
                return $"Влажность: {weatherPart.humidity}%";
            }
        }

        public string Temperature
        {
            get
            {
                return $"Температура: {weatherPart.temp_avg}(°C)" +
                    $"  Ощущается как {weatherPart.feels_like}(°C)";
            }
        }

        public string Condition
        {
            get
            {
                string condition;
                switch (weatherPart.condition)
                {
                    case "clear":
                        condition = "ясно";
                        break;
                    case "partly-cloudy":
                        condition = "малооблачно";
                        break;
                    case "cloudy":
                        condition = "облачно с прояснениями";
                        break;
                    case "overcast":
                        condition = "пасмурно";
                        break;
                    case "partly-cloudy-and-light-rain":
                        condition = "небольшой дождь";
                        break;
                    case "partly-cloudy-and-rain":
                        condition = "дождь";
                        break;
                    case "overcast-and-rain":
                        condition = "сильный дождь";
                        break;
                    case "overcast-thunderstorms-with-rain":
                        condition = "сильный дождь, гроза";
                        break;
                    case "cloudy-and-light-rain":
                        condition = "небольшой дождь";
                        break;
                    case "overcast-and-light-rain":
                        condition = "небольшой дождь";
                        break;
                    case "cloudy-and-rain":
                        condition = "дождь";
                        break;
                    case "overcast-and-wet-snow":
                        condition = "дождь со снегом";
                        break;
                    case "partly-cloudy-and-light-snow":
                        condition = "небольшой снег";
                        break;
                    case "partly-cloudy-and-snow":
                        condition = "снег";
                        break;
                    case "overcast-and-snow":
                        condition = "снегопад";
                        break;
                    case "cloudy-and-light-snow":
                        condition = "небольшой снег";
                        break;
                    case "overcast-and-light-snow":
                        condition = "небольшой снег";
                        break;
                    case "cloudy-and-snow":
                        condition = "снег";
                        break;
                    default:
                        condition = "неизвестно";
                        break;
                }
                return $"Условия: {condition}";
            }
        }

        public WeatherTodayPartViewModel(Part weatherPart)
        {
            this.weatherPart = weatherPart;
        }
    }
}
