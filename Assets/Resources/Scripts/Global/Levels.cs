using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Level {

    public static char[] completed;
    private static string path = "Assets/Resources/Data/levelsComplete.txt";

    static Level() {
        StreamReader reader = new StreamReader(Level.path);
        Level.completed = reader.ReadToEnd().ToCharArray();
        reader.Close();
    }

    public static void updateCompleted() {
        StreamWriter writer = new StreamWriter(Level.path, false);
        writer.Write(new string(Level.completed));
        writer.Close();
    }
    
    public int id;
    public int width;
    public int height;
    public Vector2 start;
    public int[,] lilypads;
    public int[,] fireflies;

    public Level(int id, int width, int height, Vector2 start, int[,] lilypads, int[,] fireflies) {
        this.id = id;
        this.width = width;
        this.height = height;
        this.start = start;
        this.lilypads = lilypads;
        this.fireflies = fireflies;
    }
}

public class Levels {

    public static Level l1 = new Level(0,
        3, 3,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 3, 3 },
            { 3, 1, 3 },
            { 3, 3, 3 },
        },
        new int[,] { 
            { 0, 1, 0 },
            { 1, 2, 1 },
            { 0, 1, 0 },
        }
    );
    public static Level l2 = new Level(1,
        3, 3,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 2, 3 },
            { 2, 2, 2 },
            { 3, 2, 3 },
        },
        new int[,] { 
            { 0, 0, 1 },
            { 1, 2, 0 },
            { 1, 0, 1 },
        }
    );
    public static Level l3 = new Level(2,
        3, 3,
        new Vector2(0, 0),
        new int[,] { 
            { 2, 2, 1 },
            { 2, 2, 0 },
            { 1, 0, 0 },
        },
        new int[,] { 
            { 0, 0, 1 },
            { 0, 2, 0 },
            { 1, 0, 0 },
        }
    );
    public static Level l4 = new Level(3,
        3, 3,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 2, 1 },
            { 3, 2, 1 },
            { 3, 2, 1 },
        },
        new int[,] { 
            { 0, 0, 1 },
            { 0, 2, 0 },
            { 1, 0, 0 },
        }
    );
    public static Level l5 = new Level(4,
        3, 3,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 2, 1 },
            { 2, 0, 1 },
            { 2, 0, 1 },
        },
        new int[,] { 
            { 0, 0, 1 },
            { 0, 0, 0 },
            { 1, 0, 2 },
        }
    );
    public static Level l6 = new Level(5,
        4, 4,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 2, 1, 1},
            { 2, 2, 1, 0},
            { 1, 1, 1, 0},
            { 1, 0, 0, 1},
        },
        new int[,] { 
            { 0, 0, 1, 0},
            { 0, 2, 0, 0},
            { 1, 0, 0, 0},
            { 0, 0, 0, 0},
        }
    );
    public static Level l7 = new Level(6,
        4, 4,
        new Vector2(0, 0),
        new int[,] { 
            { 2, 3, 0, 0},
            { 1, 3, 3, 0},
            { 1, 0, 3, 0},
            { 1, 0, 0, 0},
        },
        new int[,] { 
            { 0, 0, 0, 0},
            { 1, 0, 0, 0},
            { 0, 0, 1, 0},
            { 2, 0, 0, 0},
        }
    );
    public static Level l8 = new Level(7,
        4, 4,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 2, 0, 0},
            { 1, 2, 2, 0},
            { 1, 0, 2, 2},
            { 1, 0, 0, 1},
        },
        new int[,] { 
            { 0, 0, 0, 0},
            { 0, 0, 0, 0},
            { 1, 0, 0, 0},
            { 2, 0, 0, 1},
        }
    );
    public static Level l9 = new Level(8,
        4, 4,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 1, 1, 1},
            { 0, 0, 0, 1},
            { 1, 0, 1, 2},
            { 1, 1, 1, 1},
        },
        new int[,] { 
            { 0, 0, 0, 0},
            { 0, 0, 0, 0},
            { 2, 0, 1, 0},
            { 0, 0, 0, 1},
        }
    );
    public static Level l10 = new Level(9,
        4, 4,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 1, 0, 0},
            { 1, 3, 1, 1},
            { 0, 2, 0, 0},
            { 0, 1, 0, 0},
        },
        new int[,] { 
            { 0, 2, 0, 0},
            { 1, 0, 0, 1},
            { 0, 0, 0, 0},
            { 0, 1, 0, 0},
        }
    );
    public static Level l11 = new Level(10,
        5, 5,
        new Vector2(0, 0),
        new int[,] { 
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
        },
        new int[,] { 
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
        }
    );
    public static Level l12 = new Level(11,
        5, 5,
        new Vector2(0, 0),
        new int[,] { 
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
        },
        new int[,] { 
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
        }
    );
    public static Level l13 = new Level(12,
        5, 5,
        new Vector2(0, 0),
        new int[,] { 
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
        },
        new int[,] { 
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
        }
    );
    public static Level l14 = new Level(13,
        5, 5,
        new Vector2(0, 0),
        new int[,] { 
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
        },
        new int[,] { 
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
        }
    );
    public static Level l15 = new Level(14,
        5, 5,
        new Vector2(0, 0),
        new int[,] { 
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
        },
        new int[,] { 
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0},
        }
    );
    public static Level l16 = new Level(15,
        6, 6,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 3, 0, 2, 0, 0},
            { 0, 2, 3, 2, 1, 2},
            { 2, 3, 2, 0, 1, 2},
            { 2, 2, 0, 2, 0, 3},
            { 2, 0, 3, 0, 1, 1},
            { 0, 0, 2, 3, 1, 1},
        },
        new int[,] { 
            { 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, 1, 0},
            { 0, 1, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0},
            { 1, 0, 0, 0, 2, 0},
            { 0, 0, 0, 0, 0, 1},
        }
    );
    public static Level l17 = new Level(16,
        6, 6,
        new Vector2(0, 0),
        new int[,] { 
            { 1, 3, 1, 2, 1, 2},
            { 0, 2, 3, 3, 1, 2},
            { 0, 2, 0, 0, 2, 1},
            { 0, 2, 2, 0, 2, 0},
            { 3, 3, 1, 3, 2, 0},
            { 1, 2, 0, 2, 3, 0},
        },
        new int[,] { 
            { 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 1, 0, 0},
            { 0, 0, 0, 0, 0, 0},
            { 0, 0, 2, 0, 0, 0},
            { 2, 0, 0, 0, 0, 0},
            { 1, 1, 0, 0, 1, 0},
        }
    );
    public static Level l18 = new Level(17,
        6, 6,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 2, 1, 2, 1, 0},
            { 2, 3, 0, 0, 1, 0},
            { 1, 0, 3, 0, 2, 0},
            { 1, 1, 1, 2, 1, 0},
            { 1, 1, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0},
        },
        new int[,] { 
            { 1, 1, 0, 1, 0, 0},
            { 2, 0, 0, 0, 1, 0},
            { 0, 0, 0, 0, 0, 0},
            { 0, 0, 0, 1, 0, 0},
            { 1, 1, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0},
        }
    );
    public static Level l19 = new Level(18,
        6, 6,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 3, 3, 0, 0, 0},
            { 0, 0, 1, 2, 0, 0},
            { 2, 2, 1, 1, 3, 1},
            { 2, 0, 0, 1, 3, 1},
            { 0, 1, 2, 1, 1, 2},
            { 0, 0, 0, 2, 0, 0},
        },
        new int[,] { 
            { 1, 1, 0, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0},
            { 0, 0, 1, 0, 1, 0},
            { 0, 0, 0, 0, 0, 0},
            { 0, 0, 2, 0, 0, 0},
            { 0, 0, 0, 0, 0, 0},
        }
    );
    public static Level l20 = new Level(19,
        6, 6,
        new Vector2(0, 0),
        new int[,] { 
            { 3, 0, 0, 2, 2, 2},
            { 2, 0, 1, 1, 2, 1},
            { 1, 3, 1, 2, 0, 1},
            { 2, 2, 2, 2, 2, 0},
            { 0, 1, 2, 2, 1, 0},
            { 1, 3, 3, 1, 0, 0},
        },
        new int[,] { 
            { 0, 0, 0, 0, 0, 0},
            { 1, 0, 0, 0, 0, 0},
            { 0, 1, 0, 0, 0, 0},
            { 0, 0, 1, 0, 0, 0},
            { 0, 0, 0, 1, 1, 0},
            { 2, 0, 1, 0, 0, 0},
        }
    );
}
