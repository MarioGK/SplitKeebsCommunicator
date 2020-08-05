using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using SplitKeebsCommunicator.Models;

namespace LayoutParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var rawLayout = RawLayout.FromJson(File.ReadAllText("keyboard-layout.json"));
            var layout    = new Layout();
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
                                keyObj.CherrySizeWidth = previousData.RawLayoutClass.W ?? 1;
                            }

                            //Console.WriteLine(keyObj);
                        }
                        catch (Exception)
                        {
                            //Ignore
                        }

                        //Check if key has H
                        try
                        {
                            var previousData = row[i - 1];
                            if (previousData.RawLayoutClass?.H != null)
                            {
                                keyObj.CherrySizeHeight = previousData.RawLayoutClass.H ?? 1;
                                //Console.WriteLine(keyObj);
                            }
                        }
                        catch (Exception)
                        {
                            //Ignore
                        }
                        
                        //Check if key has X
                        try
                        {
                            var previousData = row[i + 1];
                            if (previousData.RawLayoutClass?.X != null)
                            {
                                keyObj.CherryExtraWidth = previousData.RawLayoutClass.X ?? 1;
                                Console.WriteLine(keyObj);
                            }
                        }
                        catch (Exception)
                        {
                            //Ignore
                        }

                        rowObj.Keys.Add(keyObj);
                    }
                }

                layout.Rows.Add(rowObj);
            }

            File.WriteAllText("layout.json", JsonSerializer.Serialize(layout, new JsonSerializerOptions {WriteIndented = true, IgnoreNullValues = true}));
        }
    }
}