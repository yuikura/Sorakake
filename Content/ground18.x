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
 122;
 -0.01690;-0.00030;-1.23500;,
 0.23987;-0.00030;-1.20801;,
 0.23987;-0.01530;-1.20801;,
 -0.01690;-0.01530;-1.23500;,
 0.48542;-0.00030;-1.12823;,
 0.48542;-0.01530;-1.12823;,
 0.70901;-0.00030;-0.99914;,
 0.70901;-0.01530;-0.99914;,
 0.90088;-0.00030;-0.82638;,
 0.90088;-0.01530;-0.82638;,
 1.05264;-0.00030;-0.61750;,
 1.05264;-0.01530;-0.61750;,
 1.15765;-0.00030;-0.38164;,
 1.15765;-0.01530;-0.38164;,
 1.21133;-0.00030;-0.12909;,
 1.21133;-0.01530;-0.12909;,
 1.21133;-0.00030;0.12909;,
 1.21133;-0.01530;0.12909;,
 1.15765;-0.00030;0.38164;,
 1.15765;-0.01530;0.38164;,
 1.05264;-0.00030;0.61750;,
 1.05264;-0.01530;0.61750;,
 0.90088;-0.00030;0.82638;,
 0.90088;-0.01530;0.82638;,
 0.70901;-0.00030;0.99914;,
 0.70901;-0.01530;0.99914;,
 0.48542;-0.00030;1.12823;,
 0.48542;-0.01530;1.12823;,
 0.23987;-0.00030;1.20801;,
 0.23987;-0.01530;1.20801;,
 -0.01690;-0.00030;1.23500;,
 -0.01690;-0.01530;1.23500;,
 -0.27367;-0.00030;1.20801;,
 -0.27367;-0.01530;1.20801;,
 -0.51922;-0.00030;1.12823;,
 -0.51922;-0.01530;1.12823;,
 -0.74281;-0.00030;0.99914;,
 -0.74281;-0.01530;0.99914;,
 -0.93468;-0.00030;0.82638;,
 -0.93468;-0.01530;0.82638;,
 -1.08644;-0.00030;0.61750;,
 -1.08644;-0.01530;0.61750;,
 -1.19145;-0.00030;0.38164;,
 -1.19145;-0.01530;0.38164;,
 -1.24513;-0.00030;0.12909;,
 -1.24513;-0.01530;0.12909;,
 -1.24513;-0.00030;-0.12909;,
 -1.24513;-0.01530;-0.12909;,
 -1.19146;-0.00030;-0.38164;,
 -1.19146;-0.01530;-0.38164;,
 -1.08644;-0.00030;-0.61750;,
 -1.08644;-0.01530;-0.61750;,
 -0.93468;-0.00030;-0.82638;,
 -0.93468;-0.01530;-0.82638;,
 -0.74282;-0.00030;-0.99913;,
 -0.74282;-0.01530;-0.99913;,
 -0.51922;-0.00030;-1.12823;,
 -0.51922;-0.01530;-1.12823;,
 -0.27367;-0.00030;-1.20801;,
 -0.27367;-0.01530;-1.20801;,
 -0.01690;-0.00030;-1.23500;,
 -0.01690;-0.01530;-1.23500;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.00030;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;,
 -0.01690;-0.01530;0.00000;;
 
 90;
 4;0,1,2,3;,
 4;1,4,5,2;,
 4;4,6,7,5;,
 4;6,8,9,7;,
 4;8,10,11,9;,
 4;10,12,13,11;,
 4;12,14,15,13;,
 4;14,16,17,15;,
 4;16,18,19,17;,
 4;18,20,21,19;,
 4;20,22,23,21;,
 4;22,24,25,23;,
 4;24,26,27,25;,
 4;26,28,29,27;,
 4;28,30,31,29;,
 4;30,32,33,31;,
 4;32,34,35,33;,
 4;34,36,37,35;,
 4;36,38,39,37;,
 4;38,40,41,39;,
 4;40,42,43,41;,
 4;42,44,45,43;,
 4;44,46,47,45;,
 4;46,48,49,47;,
 4;48,50,51,49;,
 4;50,52,53,51;,
 4;52,54,55,53;,
 4;54,56,57,55;,
 4;56,58,59,57;,
 4;58,60,61,59;,
 3;62,1,0;,
 3;63,4,1;,
 3;64,6,4;,
 3;65,8,6;,
 3;66,10,8;,
 3;67,12,10;,
 3;68,14,12;,
 3;69,16,14;,
 3;70,18,16;,
 3;71,20,18;,
 3;72,22,20;,
 3;73,24,22;,
 3;74,26,24;,
 3;75,28,26;,
 3;76,30,28;,
 3;77,32,30;,
 3;78,34,32;,
 3;79,36,34;,
 3;80,38,36;,
 3;81,40,38;,
 3;82,42,40;,
 3;83,44,42;,
 3;84,46,44;,
 3;85,48,46;,
 3;86,50,48;,
 3;87,52,50;,
 3;88,54,52;,
 3;89,56,54;,
 3;90,58,56;,
 3;91,60,58;,
 3;92,3,2;,
 3;93,2,5;,
 3;94,5,7;,
 3;95,7,9;,
 3;96,9,11;,
 3;97,11,13;,
 3;98,13,15;,
 3;99,15,17;,
 3;100,17,19;,
 3;101,19,21;,
 3;102,21,23;,
 3;103,23,25;,
 3;104,25,27;,
 3;105,27,29;,
 3;106,29,31;,
 3;107,31,33;,
 3;108,33,35;,
 3;109,35,37;,
 3;110,37,39;,
 3;111,39,41;,
 3;112,41,43;,
 3;113,43,45;,
 3;114,45,47;,
 3;115,47,49;,
 3;116,49,51;,
 3;117,51,53;,
 3;118,53,55;,
 3;119,55,57;,
 3;120,57,59;,
 3;121,59,61;;
 
 MeshMaterialList {
  1;
  90;
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
  0;;
  Material {
   1.000000;1.000000;1.000000;1.000000;;
   0.000000;
   0.000000;0.000000;0.000000;;
   0.000000;0.000000;0.000000;;
  }
 }
 MeshNormals {
  32;
  0.000000;1.000000;0.000000;,
  -0.000001;0.000000;-1.000000;,
  0.207912;0.000000;-0.978148;,
  0.406737;0.000000;-0.913545;,
  0.587785;0.000000;-0.809017;,
  0.743145;0.000000;-0.669131;,
  0.866025;0.000000;-0.500000;,
  0.951057;0.000000;-0.309017;,
  0.994522;0.000000;-0.104528;,
  0.994522;0.000000;0.104529;,
  0.951056;0.000000;0.309017;,
  0.866025;0.000000;0.500000;,
  0.743145;0.000000;0.669131;,
  0.587785;0.000000;0.809017;,
  0.406737;0.000000;0.913545;,
  0.207912;0.000000;0.978148;,
  -0.000000;0.000000;1.000000;,
  -0.207912;0.000000;0.978148;,
  -0.406737;0.000000;0.913545;,
  -0.587785;0.000000;0.809017;,
  -0.743145;0.000000;0.669131;,
  -0.866025;0.000000;0.500000;,
  -0.951057;0.000000;0.309017;,
  -0.994522;0.000000;0.104529;,
  -0.994522;0.000000;-0.104528;,
  -0.951057;0.000000;-0.309016;,
  -0.866026;0.000000;-0.499999;,
  -0.743146;0.000000;-0.669130;,
  -0.587786;0.000000;-0.809016;,
  -0.406738;0.000000;-0.913545;,
  -0.207913;0.000000;-0.978147;,
  0.000000;-1.000000;-0.000000;;
  90;
  4;1,2,2,1;,
  4;2,3,3,2;,
  4;3,4,4,3;,
  4;4,5,5,4;,
  4;5,6,6,5;,
  4;6,7,7,6;,
  4;7,8,8,7;,
  4;8,9,9,8;,
  4;9,10,10,9;,
  4;10,11,11,10;,
  4;11,12,12,11;,
  4;12,13,13,12;,
  4;13,14,14,13;,
  4;14,15,15,14;,
  4;15,16,16,15;,
  4;16,17,17,16;,
  4;17,18,18,17;,
  4;18,19,19,18;,
  4;19,20,20,19;,
  4;20,21,21,20;,
  4;21,22,22,21;,
  4;22,23,23,22;,
  4;23,24,24,23;,
  4;24,25,25,24;,
  4;25,26,26,25;,
  4;26,27,27,26;,
  4;27,28,28,27;,
  4;28,29,29,28;,
  4;29,30,30,29;,
  4;30,1,1,30;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;0,0,0;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;,
  3;31,31,31;;
 }
 MeshTextureCoords {
  122;
  0.000000;0.000000;,
  0.033333;0.000000;,
  0.033333;1.000000;,
  0.000000;1.000000;,
  0.066667;0.000000;,
  0.066667;1.000000;,
  0.100000;0.000000;,
  0.100000;1.000000;,
  0.133333;0.000000;,
  0.133333;1.000000;,
  0.166667;0.000000;,
  0.166667;1.000000;,
  0.200000;0.000000;,
  0.200000;1.000000;,
  0.233333;0.000000;,
  0.233333;1.000000;,
  0.266667;0.000000;,
  0.266667;1.000000;,
  0.300000;0.000000;,
  0.300000;1.000000;,
  0.333333;0.000000;,
  0.333333;1.000000;,
  0.366667;0.000000;,
  0.366667;1.000000;,
  0.400000;0.000000;,
  0.400000;1.000000;,
  0.433333;0.000000;,
  0.433333;1.000000;,
  0.466667;0.000000;,
  0.466667;1.000000;,
  0.500000;0.000000;,
  0.500000;1.000000;,
  0.533333;0.000000;,
  0.533333;1.000000;,
  0.566667;0.000000;,
  0.566667;1.000000;,
  0.600000;0.000000;,
  0.600000;1.000000;,
  0.633333;0.000000;,
  0.633333;1.000000;,
  0.666667;0.000000;,
  0.666667;1.000000;,
  0.700000;0.000000;,
  0.700000;1.000000;,
  0.733334;0.000000;,
  0.733334;1.000000;,
  0.766667;0.000000;,
  0.766667;1.000000;,
  0.800000;0.000000;,
  0.800000;1.000000;,
  0.833334;0.000000;,
  0.833334;1.000000;,
  0.866667;0.000000;,
  0.866667;1.000000;,
  0.900000;0.000000;,
  0.900000;1.000000;,
  0.933334;0.000000;,
  0.933334;1.000000;,
  0.966667;0.000000;,
  0.966667;1.000000;,
  1.000000;0.000000;,
  1.000000;1.000000;,
  0.016667;0.000000;,
  0.050000;0.000000;,
  0.083333;0.000000;,
  0.116667;0.000000;,
  0.150000;0.000000;,
  0.183333;0.000000;,
  0.216667;0.000000;,
  0.250000;0.000000;,
  0.283333;0.000000;,
  0.316667;0.000000;,
  0.350000;0.000000;,
  0.383333;0.000000;,
  0.416667;0.000000;,
  0.450000;0.000000;,
  0.483333;0.000000;,
  0.516667;0.000000;,
  0.550000;0.000000;,
  0.583333;0.000000;,
  0.616667;0.000000;,
  0.650000;0.000000;,
  0.683333;0.000000;,
  0.716667;0.000000;,
  0.750000;0.000000;,
  0.783334;0.000000;,
  0.816667;0.000000;,
  0.850000;0.000000;,
  0.883334;0.000000;,
  0.916667;0.000000;,
  0.950000;0.000000;,
  0.983334;0.000000;,
  0.016667;1.000000;,
  0.050000;1.000000;,
  0.083333;1.000000;,
  0.116667;1.000000;,
  0.150000;1.000000;,
  0.183333;1.000000;,
  0.216667;1.000000;,
  0.250000;1.000000;,
  0.283333;1.000000;,
  0.316667;1.000000;,
  0.350000;1.000000;,
  0.383333;1.000000;,
  0.416667;1.000000;,
  0.450000;1.000000;,
  0.483333;1.000000;,
  0.516667;1.000000;,
  0.550000;1.000000;,
  0.583333;1.000000;,
  0.616667;1.000000;,
  0.650000;1.000000;,
  0.683333;1.000000;,
  0.716667;1.000000;,
  0.750000;1.000000;,
  0.783334;1.000000;,
  0.816667;1.000000;,
  0.850000;1.000000;,
  0.883334;1.000000;,
  0.916667;1.000000;,
  0.950000;1.000000;,
  0.983334;1.000000;;
 }
 MeshVertexColors {
  122;
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
  90;1.000000;1.000000;1.000000;1.000000;,
  91;1.000000;1.000000;1.000000;1.000000;,
  92;1.000000;1.000000;1.000000;1.000000;,
  93;1.000000;1.000000;1.000000;1.000000;,
  94;1.000000;1.000000;1.000000;1.000000;,
  95;1.000000;1.000000;1.000000;1.000000;,
  96;1.000000;1.000000;1.000000;1.000000;,
  97;1.000000;1.000000;1.000000;1.000000;,
  98;1.000000;1.000000;1.000000;1.000000;,
  99;1.000000;1.000000;1.000000;1.000000;,
  100;1.000000;1.000000;1.000000;1.000000;,
  101;1.000000;1.000000;1.000000;1.000000;,
  102;1.000000;1.000000;1.000000;1.000000;,
  103;1.000000;1.000000;1.000000;1.000000;,
  104;1.000000;1.000000;1.000000;1.000000;,
  105;1.000000;1.000000;1.000000;1.000000;,
  106;1.000000;1.000000;1.000000;1.000000;,
  107;1.000000;1.000000;1.000000;1.000000;,
  108;1.000000;1.000000;1.000000;1.000000;,
  109;1.000000;1.000000;1.000000;1.000000;,
  110;1.000000;1.000000;1.000000;1.000000;,
  111;1.000000;1.000000;1.000000;1.000000;,
  112;1.000000;1.000000;1.000000;1.000000;,
  113;1.000000;1.000000;1.000000;1.000000;,
  114;1.000000;1.000000;1.000000;1.000000;,
  115;1.000000;1.000000;1.000000;1.000000;,
  116;1.000000;1.000000;1.000000;1.000000;,
  117;1.000000;1.000000;1.000000;1.000000;,
  118;1.000000;1.000000;1.000000;1.000000;,
  119;1.000000;1.000000;1.000000;1.000000;,
  120;1.000000;1.000000;1.000000;1.000000;,
  121;1.000000;1.000000;1.000000;1.000000;;
 }
}
