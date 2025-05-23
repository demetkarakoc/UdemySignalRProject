﻿using AutoMapper;
using SignalR.DtoLayer.NotificationDto;
using SignalR.DtoLayer.NotificationDtos;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class NotificationMapping:Profile
	{
        public NotificationMapping()
        {
            CreateMap<ResultNotificationDto, Notification>().ReverseMap();
            CreateMap<CreateNotificationDto, Notification>().ReverseMap();
            CreateMap<UpdateNotificationDto, Notification>().ReverseMap();
            CreateMap<GetNotificationDto, Notification>().ReverseMap();
        }
    }
}
