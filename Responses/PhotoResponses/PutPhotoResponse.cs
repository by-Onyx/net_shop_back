﻿using net_shop_back.Models;

namespace net_shop_back.Responses.PhotoResponses;

public record PutPhotoResponse
{
    public required PhotoModel Photo { get; set; }
}