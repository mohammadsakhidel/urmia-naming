using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Pair {
    public Pair(string key, int val) {
        this.Key = key;
        this.Value = val;
    }

    public string Key { get; set; }
    public int Value { get; set; }

}