﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Cashing;

public interface ICacheService
{
    void Add(string key, object value, int duration);
    object Get(string key);
    T Get<T>(string key);
    bool IsAdd(string key);
    void Remove(string key);
}
