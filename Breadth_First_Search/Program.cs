using BreadthFirst;

Console.WriteLine("No. 1 Res = " + Charlie.GetDistanceToNearstFoodItemsAndThenHome(new string[] { "FFOO",
                                                                                                  "COOO",
                                                                                                  "HOOF",
                                                                                                  "OOOO" }) + " Should be 9");

Console.WriteLine("No. 2 Res = " + Charlie.GetDistanceToNearstFoodItemsAndThenHome(new string[] { "OOOO",
                                                                                                  "OOFF",
                                                                                                  "OCHO",
                                                                                                  "OFOO" }) + " Should be 7");

Console.WriteLine("No. 2 Res = " + Charlie.GetDistanceToNearstFoodItemsAndThenHome(new string[] { "FOOO",
                                                                                                  "OCOH",
                                                                                                  "OFOF",
                                                                                                  "OFOO" }) + " Should be 14 (could have been 10)");

Console.WriteLine("No. 2 Res = " + Charlie.GetDistanceToNearstFoodItemsAndThenHome(new string[] { "OHOO",
                                                                                                  "OOFF",
                                                                                                  "OOOC",
                                                                                                  "OFOO" }) + " Should be 8");
Console.ReadLine();
