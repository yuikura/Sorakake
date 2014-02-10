xof 0302txt 0064
template Header {
 <3D82AB43-62DA-11cf-AB39-0020AF71E433>
 WORD major;
 WORD minor;
 DWORD flags;
}

template Vector {
 <3D82AB5E-62DA-11cf-AB39-0020AF71E433>
 FLOAT x;
 FLOAT y;
 FLOAT z;
}

template Coords2d {
 <F6F23F44-7686-11cf-8F52-0040333594A3>
 FLOAT u;
 FLOAT v;
}

template Matrix4x4 {
 <F6F23F45-7686-11cf-8F52-0040333594A3>
 array FLOAT matrix[16];
}

template ColorRGBA {
 <35FF44E0-6C7C-11cf-8F52-0040333594A3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
 FLOAT alpha;
}

template ColorRGB {
 <D3E16E81-7835-11cf-8F52-0040333594A3>
 FLOAT red;
 FLOAT green;
 FLOAT blue;
}

template IndexedColor {
 <1630B820-7842-11cf-8F52-0040333594A3>
 DWORD index;
 ColorRGBA indexColor;
}

template Boolean {
 <4885AE61-78E8-11cf-8F52-0040333594A3>
 WORD truefalse;
}

template Boolean2d {
 <4885AE63-78E8-11cf-8F52-0040333594A3>
 Boolean u;
 Boolean v;
}

template MaterialWrap {
 <4885AE60-78E8-11cf-8F52-0040333594A3>
 Boolean u;
 Boolean v;
}

template TextureFilename {
 <A42790E1-7810-11cf-8F52-0040333594A3>
 STRING filename;
}

template Material {
 <3D82AB4D-62DA-11cf-AB39-0020AF71E433>
 ColorRGBA faceColor;
 FLOAT power;
 ColorRGB specularColor;
 ColorRGB emissiveColor;
 [...]
}

template MeshFace {
 <3D82AB5F-62DA-11cf-AB39-0020AF71E433>
 DWORD nFaceVertexIndices;
 array DWORD faceVertexIndices[nFaceVertexIndices];
}

template MeshFaceWraps {
 <4885AE62-78E8-11cf-8F52-0040333594A3>
 DWORD nFaceWrapValues;
 Boolean2d faceWrapValues;
}

template MeshTextureCoords {
 <F6F23F40-7686-11cf-8F52-0040333594A3>
 DWORD nTextureCoords;
 array Coords2d textureCoords[nTextureCoords];
}

template MeshMaterialList {
 <F6F23F42-7686-11cf-8F52-0040333594A3>
 DWORD nMaterials;
 DWORD nFaceIndexes;
 array DWORD faceIndexes[nFaceIndexes];
 [Material]
}

template MeshNormals {
 <F6F23F43-7686-11cf-8F52-0040333594A3>
 DWORD nNormals;
 array Vector normals[nNormals];
 DWORD nFaceNormals;
 array MeshFace faceNormals[nFaceNormals];
}

template MeshVertexColors {
 <1630B821-7842-11cf-8F52-0040333594A3>
 DWORD nVertexColors;
 array IndexedColor vertexColors[nVertexColors];
}

template Mesh {
 <3D82AB44-62DA-11cf-AB39-0020AF71E433>
 DWORD nVertices;
 array Vector vertices[nVertices];
 DWORD nFaces;
 array MeshFace faces[nFaces];
 [...]
}

Header{
1;
0;
1;
}

Mesh {
 91;
 11.25130;0.44380;0.00000;,
 41.19320;0.44380;-55.31670;,
 85.82750;0.44380;-34.79680;,
 171.25330;0.44380;0.00000;,
 -3.71970;0.44380;0.00000;,
 1.89450;0.44380;-71.07710;,
 -22.43330;0.44380;0.00000;,
 -166.99490;0.44380;0.00000;,
 -167.08569;0.44380;-94.66880;,
 -27.11180;0.44380;-81.88710;,
 -167.93050;33.36000;-99.41520;,
 -23.36900;33.36000;-99.41520;,
 -23.36900;50.40870;-99.41520;,
 -167.93050;50.40870;-99.41520;,
 -167.93050;33.83000;0.00000;,
 -167.93050;50.40870;0.00000;,
 -23.36900;33.36000;0.00000;,
 46.80730;33.36000;-95.93640;,
 46.80730;50.40870;-95.93640;,
 -4.65530;33.36000;0.00000;,
 122.59770;33.36000;-71.60860;,
 122.59770;50.40870;-71.60860;,
 10.31560;33.36000;0.00000;,
 162.83220;33.36000;-45.40940;,
 217.10201;33.36000;0.00000;,
 217.10201;50.40870;0.00000;,
 162.83220;50.40870;-45.40940;,
 -27.11180;0.44380;-81.88710;,
 217.10201;50.40870;0.00000;,
 -167.93050;50.40870;0.00000;,
 85.82750;0.44380;34.79680;,
 41.19320;0.44380;55.31670;,
 1.89450;0.44380;71.07710;,
 -27.11180;0.44380;81.88710;,
 -167.08569;0.44380;94.66880;,
 -167.93050;50.40870;99.41520;,
 -23.36900;50.40870;99.41520;,
 -23.36900;33.36000;99.41520;,
 -167.93050;33.36000;99.41520;,
 46.80730;50.40870;95.93640;,
 46.80730;33.36000;95.93640;,
 122.59770;50.40870;71.60860;,
 122.59770;33.36000;71.60860;,
 162.83220;50.40870;45.40940;,
 162.83220;33.36000;45.40940;,
 -27.11180;0.44380;81.88710;,
 1.57960;435.49438;0.59190;,
 4.40810;425.79581;-2.23650;,
 1.57960;425.79581;-3.40810;,
 1.57960;435.49438;0.59190;,
 5.57960;425.79581;0.59190;,
 1.57960;435.49438;0.59190;,
 4.40810;425.79581;3.42040;,
 1.57960;435.49438;0.59190;,
 1.57960;425.79581;4.59190;,
 1.57960;435.49438;0.59190;,
 -1.24880;425.79581;3.42040;,
 1.57960;435.49438;0.59190;,
 -2.42040;425.79581;0.59190;,
 1.57960;435.49438;0.59190;,
 -1.24880;425.79581;-2.23650;,
 1.57960;435.49438;0.59190;,
 1.57960;425.79581;-3.40810;,
 1.57960;33.79580;0.59190;,
 1.57960;33.79580;-3.40810;,
 4.40810;33.79580;-2.23650;,
 1.57960;33.79580;0.59190;,
 5.57960;33.79580;0.59190;,
 1.57960;33.79580;0.59190;,
 4.40810;33.79580;3.42040;,
 1.57960;33.79580;0.59190;,
 1.57960;33.79580;4.59190;,
 1.57960;33.79580;0.59190;,
 -1.24880;33.79580;3.42040;,
 1.57960;33.79580;0.59190;,
 -2.42040;33.79580;0.59190;,
 1.57960;33.79580;0.59190;,
 -1.24880;33.79580;-2.23650;,
 1.57960;33.79580;0.59190;,
 1.57960;33.79580;-3.40810;,
 4.40810;121.77110;-2.23650;,
 1.57960;121.77110;-3.40810;,
 5.57960;121.77110;0.59190;,
 4.40810;121.77110;3.42040;,
 1.57960;121.77110;4.59190;,
 -1.24880;121.77110;3.42040;,
 -2.42040;121.77110;0.59190;,
 -1.24880;121.77110;-2.23650;,
 1.57960;121.77110;-3.40810;,
 -200.18340;125.03130;0.00000;,
 206.64450;122.20070;0.00000;;
 
 88;
 4;0,1,2,3;,
 4;4,5,1,0;,
 4;6,7,8,9;,
 4;6,9,5,4;,
 4;10,11,12,13;,
 4;14,10,13,15;,
 4;11,10,14,16;,
 4;11,17,18,12;,
 4;11,16,19,17;,
 4;17,20,21,18;,
 4;17,19,22,20;,
 4;23,24,25,26;,
 4;20,23,26,21;,
 4;20,22,24,23;,
 4;5,27,11,17;,
 4;10,11,27,8;,
 4;12,11,10,13;,
 4;18,17,11,12;,
 4;17,18,21,20;,
 4;5,17,20,1;,
 4;20,21,26,23;,
 4;26,28,24,23;,
 4;20,23,2,1;,
 4;23,24,3,2;,
 4;10,8,7,14;,
 4;13,10,14,29;,
 4;3,30,31,0;,
 4;0,31,32,4;,
 4;33,34,7,6;,
 4;4,32,33,6;,
 4;35,36,37,38;,
 4;15,35,38,14;,
 4;16,14,38,37;,
 4;36,39,40,37;,
 4;40,19,16,37;,
 4;39,41,42,40;,
 4;42,22,19,40;,
 4;43,25,24,44;,
 4;41,43,44,42;,
 4;44,24,22,42;,
 4;40,37,45,32;,
 4;34,45,37,38;,
 4;35,38,37,36;,
 4;36,37,40,39;,
 4;42,41,39,40;,
 4;31,42,40,32;,
 4;44,43,41,42;,
 4;44,24,28,43;,
 4;31,30,44,42;,
 4;30,3,24,44;,
 4;14,7,34,38;,
 4;29,14,38,35;,
 3;46,47,48;,
 3;49,50,47;,
 3;51,52,50;,
 3;53,54,52;,
 3;55,56,54;,
 3;57,58,56;,
 3;59,60,58;,
 3;61,62,60;,
 3;63,64,65;,
 3;66,65,67;,
 3;68,67,69;,
 3;70,69,71;,
 3;72,71,73;,
 3;74,73,75;,
 3;76,75,77;,
 3;78,77,79;,
 4;80,65,64,81;,
 4;80,81,48,47;,
 4;82,67,65,80;,
 4;82,80,47,50;,
 4;83,69,67,82;,
 4;83,82,50,52;,
 4;84,71,69,83;,
 4;84,83,52,54;,
 4;85,73,71,84;,
 4;85,84,54,56;,
 4;86,75,73,85;,
 4;86,85,56,58;,
 4;87,77,75,86;,
 4;87,86,58,60;,
 4;88,79,77,87;,
 4;88,87,60,62;,
 4;86,89,58,50;,
 3;90,82,50;,
 3;90,50,82;,
 3;58,89,86;;
 
 MeshMaterialList {
  4;
  88;
  0,
  0,
  0,
  0,
  0,
  0,
  1,
  0,
  1,
  0,
  1,
  0,
  0,
  1,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  1,
  0,
  1,
  0,
  1,
  0,
  0,
  1,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  0,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  2,
  3,
  3,
  3,
  3;;
  Material {
   0.059000;0.173000;0.310000;1.000000;;
   5.000000;
   0.000000;0.000000;0.000000;;
   0.034220;0.100340;0.179800;;
  }
  Material {
   0.586400;0.552000;0.220000;1.000000;;
   5.000000;
   0.000000;0.000000;0.000000;;
   0.000000;0.000000;0.000000;;
  }
  Material {
   0.800000;0.392000;0.119200;1.000000;;
   5.000000;
   0.000000;0.000000;0.000000;;
   0.000000;0.000000;0.000000;;
  }
  Material {
   0.819608;0.658824;0.619608;1.000000;;
   5.000000;
   0.000000;0.000000;0.000000;;
   0.557333;0.448000;0.421333;;
  }
 }
 MeshNormals {
  92;
  0.000000;0.000000;1.000000;,
  0.000000;-1.000000;0.000000;,
  -0.594760;0.000000;0.803903;,
  0.221399;-0.899302;-0.377146;,
  1.000000;0.000000;0.000000;,
  -0.641722;0.000000;0.766937;,
  0.207005;-0.978340;-0.000000;,
  -0.429461;0.000000;0.903086;,
  0.126528;-0.950406;-0.284111;,
  -0.179094;0.000000;0.983832;,
  0.107230;-0.916208;-0.386088;,
  -0.024763;0.000000;0.999693;,
  0.065443;-0.851016;-0.521047;,
  0.000813;1.000000;0.000000;,
  0.000000;1.000000;0.000000;,
  0.000000;0.000000;-1.000000;,
  -0.594760;0.000000;-0.803903;,
  0.221399;-0.899302;0.377146;,
  -0.429461;0.000000;-0.903086;,
  0.126528;-0.950406;0.284111;,
  -0.179094;0.000000;-0.983832;,
  0.107230;-0.916208;0.386088;,
  -0.024763;0.000000;-0.999693;,
  0.065443;-0.851016;0.521047;,
  0.000813;0.999999;-0.001182;,
  0.001626;0.999996;-0.002364;,
  0.001626;0.999999;0.000000;,
  0.069924;-0.225459;-0.971740;,
  0.202124;-0.361930;-0.910029;,
  0.023173;-0.156958;-0.987333;,
  0.045758;-0.309940;-0.949654;,
  0.024763;0.000000;-0.999693;,
  0.179094;0.000000;-0.983832;,
  0.429461;0.000000;-0.903086;,
  0.375310;-0.453248;-0.808523;,
  0.594760;0.000000;-0.803903;,
  0.506063;-0.433418;-0.745687;,
  0.641722;0.000000;-0.766937;,
  0.547720;-0.392466;-0.738900;,
  -0.999910;-0.013414;0.000270;,
  -0.999640;-0.026826;0.000540;,
  -0.999640;-0.026826;0.000000;,
  -0.999910;-0.013414;0.000000;,
  -1.000000;0.000000;0.000000;,
  0.001626;0.999996;0.002364;,
  0.000813;0.999999;0.001182;,
  -0.641722;0.000000;-0.766937;,
  0.202124;-0.361930;0.910029;,
  0.069924;-0.225459;0.971740;,
  0.045758;-0.309940;0.949654;,
  0.023173;-0.156958;0.987333;,
  0.024763;0.000000;0.999693;,
  0.179094;0.000000;0.983832;,
  0.375310;-0.453248;0.808523;,
  0.429461;0.000000;0.903086;,
  0.506063;-0.433418;0.745687;,
  0.594760;0.000000;0.803903;,
  0.547720;-0.392466;0.738900;,
  0.641722;0.000000;0.766937;,
  -0.999640;-0.026826;-0.000540;,
  -0.999910;-0.013414;-0.000270;,
  0.653697;0.381280;-0.653686;,
  -0.000006;0.195389;-0.980726;,
  0.693484;0.195391;-0.693471;,
  0.980726;0.195389;-0.000006;,
  0.693477;0.195394;0.693477;,
  -0.000006;0.195389;0.980726;,
  -0.693472;0.195391;0.693484;,
  -0.980726;0.195389;-0.000006;,
  -0.693478;0.195388;-0.693478;,
  0.000000;-1.000000;0.000000;,
  -0.000006;0.000000;-1.000000;,
  0.707113;0.000000;-0.707101;,
  1.000000;0.000000;-0.000006;,
  0.707107;0.000000;0.707107;,
  -0.000006;0.000000;1.000000;,
  -0.707101;0.000000;0.707113;,
  -1.000000;0.000000;-0.000006;,
  -0.707107;0.000000;-0.707107;,
  0.001496;0.000000;-0.999999;,
  -0.002944;0.000000;-0.999996;,
  0.653690;0.381285;0.653690;,
  -0.653686;0.381280;0.653697;,
  -0.653693;0.381274;-0.653693;,
  -0.000006;0.000000;-1.000000;,
  1.000000;0.000000;-0.000006;,
  0.707107;0.000000;0.707107;,
  -0.000006;0.000000;1.000000;,
  -1.000000;0.000000;-0.000006;,
  -0.000724;0.000000;-1.000000;,
  0.002944;0.000000;0.999996;,
  -0.002993;0.000000;0.999996;;
  88;
  4;1,8,3,6;,
  4;1,10,8,1;,
  4;1,1,1,12;,
  4;1,12,10,1;,
  4;0,11,11,0;,
  4;4,4,4,4;,
  4;24,25,26,13;,
  4;11,9,9,11;,
  4;24,13,14,14;,
  4;9,7,7,9;,
  4;14,14,14,14;,
  4;2,5,5,2;,
  4;7,2,2,7;,
  4;14,14,14,14;,
  4;10,12,27,28;,
  4;29,27,12,30;,
  4;31,27,29,15;,
  4;32,28,27,31;,
  4;28,32,33,34;,
  4;10,28,34,8;,
  4;34,33,35,36;,
  4;35,37,38,36;,
  4;34,36,3,8;,
  4;36,38,6,3;,
  4;39,40,41,42;,
  4;43,39,42,43;,
  4;6,17,19,1;,
  4;1,19,21,1;,
  4;23,1,1,1;,
  4;1,21,23,1;,
  4;15,22,22,15;,
  4;4,4,4,4;,
  4;13,26,44,45;,
  4;22,20,20,22;,
  4;14,14,13,45;,
  4;20,18,18,20;,
  4;14,14,14,14;,
  4;16,46,46,16;,
  4;18,16,16,18;,
  4;14,14,14,14;,
  4;47,48,23,21;,
  4;49,23,48,50;,
  4;0,50,48,51;,
  4;51,48,47,52;,
  4;53,54,52,47;,
  4;19,53,47,21;,
  4;55,56,54,53;,
  4;55,57,58,56;,
  4;19,17,55,53;,
  4;17,6,57,55;,
  4;42,41,59,60;,
  4;43,42,60,43;,
  3;61,63,62;,
  3;61,64,63;,
  3;81,65,64;,
  3;81,66,65;,
  3;82,67,66;,
  3;82,68,67;,
  3;83,69,68;,
  3;83,62,69;,
  3;70,70,70;,
  3;70,70,70;,
  3;70,70,70;,
  3;70,70,70;,
  3;70,70,70;,
  3;70,70,70;,
  3;70,70,70;,
  3;70,70,70;,
  4;72,72,84,71;,
  4;72,71,62,63;,
  4;73,85,72,72;,
  4;73,72,63,64;,
  4;74,86,85,73;,
  4;74,73,64,65;,
  4;75,87,86,74;,
  4;75,74,65,66;,
  4;76,76,87,75;,
  4;76,75,66,67;,
  4;77,88,76,76;,
  4;77,76,67,68;,
  4;78,78,88,77;,
  4;78,77,68,69;,
  4;71,84,78,78;,
  4;71,78,69,62;,
  4;79,79,79,89;,
  3;80,80,89;,
  3;90,90,90;,
  3;91,91,91;;
 }
 MeshTextureCoords {
  91;
  0.891230;0.494190;,
  0.891230;0.000000;,
  1.000000;0.000000;,
  1.000000;0.494100;,
  0.816380;0.494250;,
  0.816380;0.000000;,
  0.722810;0.494320;,
  0.000000;0.494900;,
  0.000000;0.000000;,
  0.722810;0.000000;,
  0.000000;1.000000;,
  0.722810;1.000000;,
  0.722810;1.000000;,
  0.000000;1.000000;,
  0.000000;0.505100;,
  0.000000;0.505100;,
  0.722810;0.505680;,
  0.816380;1.000000;,
  0.816380;1.000000;,
  0.816380;0.505750;,
  0.891230;1.000000;,
  0.891230;1.000000;,
  0.891230;0.505810;,
  1.000000;1.000000;,
  1.000000;0.505900;,
  1.000000;0.505900;,
  1.000000;1.000000;,
  0.722810;1.000000;,
  0.000000;0.000000;,
  0.000000;0.000000;,
  1.000000;0.000000;,
  0.891230;0.000000;,
  0.816380;0.000000;,
  0.722810;0.000000;,
  0.000000;0.000000;,
  0.000000;1.000000;,
  0.722810;1.000000;,
  0.722810;1.000000;,
  0.000000;1.000000;,
  0.816380;1.000000;,
  0.816380;1.000000;,
  0.891230;1.000000;,
  0.891230;1.000000;,
  1.000000;1.000000;,
  1.000000;1.000000;,
  0.722810;1.000000;,
  0.062500;0.000000;,
  0.125000;0.000000;,
  0.000000;0.000000;,
  0.187500;0.000000;,
  0.250000;0.000000;,
  0.312500;0.000000;,
  0.375000;0.000000;,
  0.437500;0.000000;,
  0.500000;0.000000;,
  0.562500;0.000000;,
  0.625000;0.000000;,
  0.687500;0.000000;,
  0.750000;0.000000;,
  0.812500;0.000000;,
  0.875000;0.000000;,
  0.937500;0.000000;,
  1.000000;0.000000;,
  0.062500;1.000000;,
  0.000000;1.000000;,
  0.125000;1.000000;,
  0.187500;1.000000;,
  0.250000;1.000000;,
  0.312500;1.000000;,
  0.375000;1.000000;,
  0.437500;1.000000;,
  0.500000;1.000000;,
  0.562500;1.000000;,
  0.625000;1.000000;,
  0.687500;1.000000;,
  0.750000;1.000000;,
  0.812500;1.000000;,
  0.875000;1.000000;,
  0.937500;1.000000;,
  1.000000;1.000000;,
  0.125000;0.627090;,
  0.000000;0.627090;,
  0.250000;0.627090;,
  0.375000;0.627090;,
  0.500000;0.627090;,
  0.625000;0.627090;,
  0.750000;0.627090;,
  0.875000;0.627090;,
  1.000000;0.627090;,
  0.000000;0.000000;,
  0.000000;0.000000;;
 }
 MeshVertexColors {
  91;
  0;1.000000;1.000000;1.000000;1.000000;,
  1;1.000000;1.000000;1.000000;1.000000;,
  2;1.000000;1.000000;1.000000;1.000000;,
  3;1.000000;1.000000;1.000000;1.000000;,
  4;1.000000;1.000000;1.000000;1.000000;,
  5;1.000000;1.000000;1.000000;1.000000;,
  6;1.000000;1.000000;1.000000;1.000000;,
  7;1.000000;1.000000;1.000000;1.000000;,
  8;1.000000;1.000000;1.000000;1.000000;,
  9;1.000000;1.000000;1.000000;1.000000;,
  10;1.000000;1.000000;1.000000;1.000000;,
  11;1.000000;1.000000;1.000000;1.000000;,
  12;1.000000;1.000000;1.000000;1.000000;,
  13;1.000000;1.000000;1.000000;1.000000;,
  14;1.000000;1.000000;1.000000;1.000000;,
  15;1.000000;1.000000;1.000000;1.000000;,
  16;1.000000;1.000000;1.000000;1.000000;,
  17;1.000000;1.000000;1.000000;1.000000;,
  18;1.000000;1.000000;1.000000;1.000000;,
  19;1.000000;1.000000;1.000000;1.000000;,
  20;1.000000;1.000000;1.000000;1.000000;,
  21;1.000000;1.000000;1.000000;1.000000;,
  22;1.000000;1.000000;1.000000;1.000000;,
  23;1.000000;1.000000;1.000000;1.000000;,
  24;1.000000;1.000000;1.000000;1.000000;,
  25;1.000000;1.000000;1.000000;1.000000;,
  26;1.000000;1.000000;1.000000;1.000000;,
  27;1.000000;1.000000;1.000000;1.000000;,
  28;1.000000;1.000000;1.000000;1.000000;,
  29;1.000000;1.000000;1.000000;1.000000;,
  30;1.000000;1.000000;1.000000;1.000000;,
  31;1.000000;1.000000;1.000000;1.000000;,
  32;1.000000;1.000000;1.000000;1.000000;,
  33;1.000000;1.000000;1.000000;1.000000;,
  34;1.000000;1.000000;1.000000;1.000000;,
  35;1.000000;1.000000;1.000000;1.000000;,
  36;1.000000;1.000000;1.000000;1.000000;,
  37;1.000000;1.000000;1.000000;1.000000;,
  38;1.000000;1.000000;1.000000;1.000000;,
  39;1.000000;1.000000;1.000000;1.000000;,
  40;1.000000;1.000000;1.000000;1.000000;,
  41;1.000000;1.000000;1.000000;1.000000;,
  42;1.000000;1.000000;1.000000;1.000000;,
  43;1.000000;1.000000;1.000000;1.000000;,
  44;1.000000;1.000000;1.000000;1.000000;,
  45;1.000000;1.000000;1.000000;1.000000;,
  46;1.000000;1.000000;1.000000;1.000000;,
  47;1.000000;1.000000;1.000000;1.000000;,
  48;1.000000;1.000000;1.000000;1.000000;,
  49;1.000000;1.000000;1.000000;1.000000;,
  50;1.000000;1.000000;1.000000;1.000000;,
  51;1.000000;1.000000;1.000000;1.000000;,
  52;1.000000;1.000000;1.000000;1.000000;,
  53;1.000000;1.000000;1.000000;1.000000;,
  54;1.000000;1.000000;1.000000;1.000000;,
  55;1.000000;1.000000;1.000000;1.000000;,
  56;1.000000;1.000000;1.000000;1.000000;,
  57;1.000000;1.000000;1.000000;1.000000;,
  58;1.000000;1.000000;1.000000;1.000000;,
  59;1.000000;1.000000;1.000000;1.000000;,
  60;1.000000;1.000000;1.000000;1.000000;,
  61;1.000000;1.000000;1.000000;1.000000;,
  62;1.000000;1.000000;1.000000;1.000000;,
  63;1.000000;1.000000;1.000000;1.000000;,
  64;1.000000;1.000000;1.000000;1.000000;,
  65;1.000000;1.000000;1.000000;1.000000;,
  66;1.000000;1.000000;1.000000;1.000000;,
  67;1.000000;1.000000;1.000000;1.000000;,
  68;1.000000;1.000000;1.000000;1.000000;,
  69;1.000000;1.000000;1.000000;1.000000;,
  70;1.000000;1.000000;1.000000;1.000000;,
  71;1.000000;1.000000;1.000000;1.000000;,
  72;1.000000;1.000000;1.000000;1.000000;,
  73;1.000000;1.000000;1.000000;1.000000;,
  74;1.000000;1.000000;1.000000;1.000000;,
  75;1.000000;1.000000;1.000000;1.000000;,
  76;1.000000;1.000000;1.000000;1.000000;,
  77;1.000000;1.000000;1.000000;1.000000;,
  78;1.000000;1.000000;1.000000;1.000000;,
  79;1.000000;1.000000;1.000000;1.000000;,
  80;1.000000;1.000000;1.000000;1.000000;,
  81;1.000000;1.000000;1.000000;1.000000;,
  82;1.000000;1.000000;1.000000;1.000000;,
  83;1.000000;1.000000;1.000000;1.000000;,
  84;1.000000;1.000000;1.000000;1.000000;,
  85;1.000000;1.000000;1.000000;1.000000;,
  86;1.000000;1.000000;1.000000;1.000000;,
  87;1.000000;1.000000;1.000000;1.000000;,
  88;1.000000;1.000000;1.000000;1.000000;,
  89;1.000000;1.000000;1.000000;1.000000;,
  90;1.000000;1.000000;1.000000;1.000000;;
 }
}
