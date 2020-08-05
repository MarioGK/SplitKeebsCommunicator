using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SplitKeebsCommunicator.Models;

namespace LayoutParser
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var rawLayout = RawLayout.FromJson(File.ReadAllText("keyboard-layout.json"));
            var layout = new Layout();
            foreach (var row in rawLayout)
            {
                var rowObj = new Row {Keys = new ObservableCollection<Key>()};

                for (var i = 0; i < row.Count; i++)
                {
                    var key = row[i];

                    if (key.String != null)
                    {
                        var keyObj = new Key(key.String);
                    
                        //Check if key has W
                        try
                        {
                            var previousData = row[i - 1];
                            if (previousData.RawLayoutClass?.W != null)
                            {
                                keyObj.KeySize = previousData.RawLayoutClass.W ?? 1;
                                //Console.WriteLine(keyObj);
                            }
                        }
                        catch (Exception e)
                        {
                            //Ignore
                        }
                        
                        //Check if key has H
                        try
                        {
                            var previousData = row[i - 1];
                            if (previousData.RawLayoutClass?.H != null)
                            {
                                keyObj.KeySizeHeight = previousData.RawLayoutClass.H ?? 1;
                                Console.WriteLine(keyObj);
                            }
                        }
                        catch (Exception e)
                        {
                            //Ignore
                        }
                    
                        rowObj.Keys.Add(keyObj);
                    }


                    //Adding spacer key
                    if (key.RawLayoutClass != null)
                    {
                        var x = key.RawLayoutClass.X ?? 0;
                        if (x != 0)
                        {
                            rowObj.Keys.Add(new Key("Spacer", x));
                        }
                    }
                }

                layout.Rows.Add(rowObj);
            }
            File.WriteAllText("layout.json", System.Text.Json.JsonSerializer.Serialize(layout, new JsonSerializerOptions{WriteIndented = true}));
        }
    }
}