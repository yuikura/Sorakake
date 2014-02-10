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
 153;
 0.80000;0.00000;0.00000;,
 0.82929;0.00185;-0.07069;,
 0.76616;-0.31540;-0.07899;,
 0.73910;-0.30604;-0.00801;,
 0.90000;0.00262;-0.09997;,
 0.83149;-0.34168;-0.10898;,
 0.97071;0.00185;-0.07069;,
 0.89682;-0.36950;-0.08041;,
 1.00000;-0.00000;0.00000;,
 0.92388;-0.38255;-0.01002;,
 0.97071;-0.00185;0.07069;,
 0.89682;-0.37320;0.06096;,
 0.90000;-0.00262;0.09997;,
 0.83149;-0.34691;0.09095;,
 0.82929;-0.00185;0.07069;,
 0.76616;-0.31910;0.06238;,
 0.80000;0.00000;0.00000;,
 0.73910;-0.30604;-0.00801;,
 0.58640;-0.58434;-0.08604;,
 0.56569;-0.56549;-0.01481;,
 0.63640;-0.63356;-0.11662;,
 0.68640;-0.68431;-0.08865;,
 0.70711;-0.70686;-0.01851;,
 0.68640;-0.68801;0.05272;,
 0.63640;-0.63880;0.08331;,
 0.58640;-0.58805;0.05534;,
 0.56569;-0.56549;-0.01481;,
 0.31736;-0.76405;-0.09074;,
 0.30615;-0.73885;-0.01935;,
 0.34442;-0.82859;-0.12173;,
 0.37147;-0.89466;-0.09416;,
 0.38268;-0.92356;-0.02418;,
 0.37147;-0.89836;0.04721;,
 0.34442;-0.83382;0.07820;,
 0.31736;-0.76775;0.05063;,
 0.30615;-0.73885;-0.01935;,
 -0.00000;-0.82715;-0.09239;,
 -0.00000;-0.79973;-0.02094;,
 -0.00000;-0.89707;-0.12352;,
 -0.00000;-0.96853;-0.09610;,
 -0.00000;-0.99966;-0.02618;,
 -0.00000;-0.97223;0.04528;,
 -0.00000;-0.90231;0.07641;,
 -0.00000;-0.83086;0.04898;,
 -0.00000;-0.79973;-0.02094;,
 -0.31736;-0.76405;-0.09074;,
 -0.30615;-0.73885;-0.01935;,
 -0.34442;-0.82859;-0.12173;,
 -0.37147;-0.89466;-0.09416;,
 -0.38268;-0.92356;-0.02418;,
 -0.37147;-0.89836;0.04721;,
 -0.34442;-0.83382;0.07820;,
 -0.31736;-0.76775;0.05063;,
 -0.30615;-0.73885;-0.01935;,
 -0.58640;-0.58434;-0.08604;,
 -0.56569;-0.56549;-0.01481;,
 -0.63640;-0.63356;-0.11662;,
 -0.68640;-0.68431;-0.08865;,
 -0.70711;-0.70686;-0.01851;,
 -0.68640;-0.68801;0.05272;,
 -0.63640;-0.63880;0.08331;,
 -0.58640;-0.58805;0.05534;,
 -0.56569;-0.56549;-0.01481;,
 -0.76616;-0.31540;-0.07899;,
 -0.73910;-0.30604;-0.00801;,
 -0.83149;-0.34168;-0.10898;,
 -0.89682;-0.36950;-0.08041;,
 -0.92388;-0.38255;-0.01002;,
 -0.89682;-0.37320;0.06096;,
 -0.83149;-0.34691;0.09095;,
 -0.76616;-0.31910;0.06238;,
 -0.73910;-0.30604;-0.00801;,
 -0.82929;0.00185;-0.07069;,
 -0.80000;-0.00000;-0.00000;,
 -0.90000;0.00262;-0.09997;,
 -0.97071;0.00185;-0.07069;,
 -1.00000;-0.00000;0.00000;,
 -0.97071;-0.00185;0.07069;,
 -0.90000;-0.00262;0.09997;,
 -0.82929;-0.00185;0.07069;,
 -0.80000;-0.00000;-0.00000;,
 -0.76616;0.31910;-0.06238;,
 -0.73910;0.30604;0.00801;,
 -0.83149;0.34691;-0.09095;,
 -0.89682;0.37320;-0.06096;,
 -0.92388;0.38255;0.01002;,
 -0.89682;0.36950;0.08041;,
 -0.83149;0.34168;0.10898;,
 -0.76616;0.31540;0.07899;,
 -0.73910;0.30604;0.00801;,
 -0.58640;0.58805;-0.05534;,
 -0.56569;0.56549;0.01481;,
 -0.63640;0.63879;-0.08331;,
 -0.68640;0.68801;-0.05272;,
 -0.70711;0.70686;0.01851;,
 -0.68640;0.68431;0.08865;,
 -0.63640;0.63356;0.11662;,
 -0.58640;0.58434;0.08604;,
 -0.56569;0.56549;0.01481;,
 -0.31736;0.76775;-0.05063;,
 -0.30615;0.73885;0.01935;,
 -0.34442;0.83382;-0.07820;,
 -0.37148;0.89836;-0.04721;,
 -0.38268;0.92356;0.02418;,
 -0.37148;0.89466;0.09416;,
 -0.34442;0.82859;0.12173;,
 -0.31736;0.76405;0.09074;,
 -0.30615;0.73885;0.01935;,
 0.00000;0.83086;-0.04898;,
 0.00000;0.79973;0.02094;,
 0.00000;0.90231;-0.07641;,
 0.00000;0.97223;-0.04528;,
 0.00000;0.99966;0.02618;,
 0.00000;0.96853;0.09610;,
 0.00000;0.89707;0.12352;,
 0.00000;0.82715;0.09239;,
 0.00000;0.79973;0.02094;,
 0.31736;0.76775;-0.05063;,
 0.30615;0.73885;0.01935;,
 0.34442;0.83382;-0.07820;,
 0.37148;0.89836;-0.04721;,
 0.38268;0.92356;0.02418;,
 0.37148;0.89466;0.09416;,
 0.34442;0.82859;0.12173;,
 0.31736;0.76405;0.09074;,
 0.30615;0.73885;0.01935;,
 0.58640;0.58805;-0.05534;,
 0.56569;0.56549;0.01481;,
 0.63640;0.63879;-0.08331;,
 0.68640;0.68801;-0.05272;,
 0.70711;0.70686;0.01851;,
 0.68640;0.68431;0.08865;,
 0.63640;0.63356;0.11662;,
 0.58640;0.58434;0.08604;,
 0.56569;0.56549;0.01481;,
 0.76616;0.31910;-0.06238;,
 0.73910;0.30604;0.00801;,
 0.83149;0.34691;-0.09095;,
 0.89682;0.37320;-0.06096;,
 0.92388;0.38255;0.01002;,
 0.89682;0.36950;0.08041;,
 0.83149;0.34168;0.10898;,
 0.76616;0.31540;0.07899;,
 0.73910;0.30604;0.00801;,
 0.82929;0.00185;-0.07069;,
 0.80000;0.00000;0.00000;,
 0.90000;0.00262;-0.09997;,
 0.97071;0.00185;-0.07069;,
 1.00000;-0.00000;0.00000;,
 0.97071;-0.00185;0.07069;,
 0.90000;-0.00262;0.09997;,
 0.82929;-0.00185;0.07069;,
 0.80000;0.00000;0.00000;;
 
 128;
 4;0,1,2,3;,
 4;1,4,5,2;,
 4;4,6,7,5;,
 4;6,8,9,7;,
 4;8,10,11,9;,
 4;10,12,13,11;,
 4;12,14,15,13;,
 4;14,16,17,15;,
 4;3,2,18,19;,
 4;2,5,20,18;,
 4;5,7,21,20;,
 4;7,9,22,21;,
 4;9,11,23,22;,
 4;11,13,24,23;,
 4;13,15,25,24;,
 4;15,17,26,25;,
 4;19,18,27,28;,
 4;18,20,29,27;,
 4;20,21,30,29;,
 4;21,22,31,30;,
 4;22,23,32,31;,
 4;23,24,33,32;,
 4;24,25,34,33;,
 4;25,26,35,34;,
 4;28,27,36,37;,
 4;27,29,38,36;,
 4;29,30,39,38;,
 4;30,31,40,39;,
 4;31,32,41,40;,
 4;32,33,42,41;,
 4;33,34,43,42;,
 4;34,35,44,43;,
 4;37,36,45,46;,
 4;36,38,47,45;,
 4;38,39,48,47;,
 4;39,40,49,48;,
 4;40,41,50,49;,
 4;41,42,51,50;,
 4;42,43,52,51;,
 4;43,44,53,52;,
 4;46,45,54,55;,
 4;45,47,56,54;,
 4;47,48,57,56;,
 4;48,49,58,57;,
 4;49,50,59,58;,
 4;50,51,60,59;,
 4;51,52,61,60;,
 4;52,53,62,61;,
 4;55,54,63,64;,
 4;54,56,65,63;,
 4;56,57,66,65;,
 4;57,58,67,66;,
 4;58,59,68,67;,
 4;59,60,69,68;,
 4;60,61,70,69;,
 4;61,62,71,70;,
 4;64,63,72,73;,
 4;63,65,74,72;,
 4;65,66,75,74;,
 4;66,67,76,75;,
 4;67,68,77,76;,
 4;68,69,78,77;,
 4;69,70,79,78;,
 4;70,71,80,79;,
 4;73,72,81,82;,
 4;72,74,83,81;,
 4;74,75,84,83;,
 4;75,76,85,84;,
 4;76,77,86,85;,
 4;77,78,87,86;,
 4;78,79,88,87;,
 4;79,80,89,88;,
 4;82,81,90,91;,
 4;81,83,92,90;,
 4;83,84,93,92;,
 4;84,85,94,93;,
 4;85,86,95,94;,
 4;86,87,96,95;,
 4;87,88,97,96;,
 4;88,89,98,97;,
 4;91,90,99,100;,
 4;90,92,101,99;,
 4;92,93,102,101;,
 4;93,94,103,102;,
 4;94,95,104,103;,
 4;95,96,105,104;,
 4;96,97,106,105;,
 4;97,98,107,106;,
 4;100,99,108,109;,
 4;99,101,110,108;,
 4;101,102,111,110;,
 4;102,103,112,111;,
 4;103,104,113,112;,
 4;104,105,114,113;,
 4;105,106,115,114;,
 4;106,107,116,115;,
 4;109,108,117,118;,
 4;108,110,119,117;,
 4;110,111,120,119;,
 4;111,112,121,120;,
 4;112,113,122,121;,
 4;113,114,123,122;,
 4;114,115,124,123;,
 4;115,116,125,124;,
 4;118,117,126,127;,
 4;117,119,128,126;,
 4;119,120,129,128;,
 4;120,121,130,129;,
 4;121,122,131,130;,
 4;122,123,132,131;,
 4;123,124,133,132;,
 4;124,125,134,133;,
 4;127,126,135,136;,
 4;126,128,137,135;,
 4;128,129,138,137;,
 4;129,130,139,138;,
 4;130,131,140,139;,
 4;131,132,141,140;,
 4;132,133,142,141;,
 4;133,134,143,142;,
 4;136,135,144,145;,
 4;135,137,146,144;,
 4;137,138,147,146;,
 4;138,139,148,147;,
 4;139,140,149,148;,
 4;140,141,150,149;,
 4;141,142,151,150;,
 4;142,143,152,151;;
 
 MeshMaterialList {
  1;
  128;
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
   0.800000;0.800000;0.800000;1.000000;;
   5.000000;
   0.000000;0.000000;0.000000;;
   0.000000;0.000000;0.000000;;
   TextureFilename {
    "Yello.png";
   }
  }
 }
 MeshNormals {
  128;
  -1.000000;0.000000;-0.000000;,
  -0.705095;0.018563;-0.708870;,
  -0.000000;0.026177;-0.999657;,
  0.705095;0.018562;-0.708870;,
  1.000000;-0.000000;-0.000000;,
  0.705095;-0.018563;0.708870;,
  -0.000000;-0.026177;0.999657;,
  -0.705095;-0.018562;0.708870;,
  -0.923879;0.382553;0.010017;,
  -0.651422;0.288298;-0.701807;,
  -0.000000;0.026177;-0.999657;,
  0.651422;-0.251173;-0.715934;,
  0.923880;-0.382552;-0.010018;,
  0.651422;-0.288298;0.701807;,
  0.000000;-0.026177;0.999657;,
  -0.651423;0.251174;0.715933;,
  -0.707107;0.706865;0.018508;,
  -0.498577;0.516969;-0.695819;,
  0.000000;0.026177;-0.999657;,
  0.498577;-0.479845;-0.721921;,
  0.707106;-0.706865;-0.018510;,
  0.498577;-0.516969;0.695819;,
  0.000000;-0.026178;0.999657;,
  -0.498577;0.479844;0.721921;,
  -0.382683;0.923563;0.024184;,
  -0.269828;0.669761;-0.691818;,
  0.000000;0.026175;-0.999657;,
  0.269828;-0.632638;-0.725922;,
  0.382683;-0.923563;-0.024185;,
  0.269828;-0.669762;0.691818;,
  0.000000;-0.026179;0.999657;,
  -0.269828;0.632636;0.725924;,
  0.000000;0.999657;0.026177;,
  -0.000000;0.723415;-0.690414;,
  -0.000000;0.026174;-0.999657;,
  -0.000000;-0.686292;-0.727327;,
  -0.000000;-0.999657;-0.026178;,
  0.000000;-0.723415;0.690413;,
  0.000000;-0.026178;0.999657;,
  0.000000;0.686289;0.727329;,
  0.382683;0.923563;0.024184;,
  0.269828;0.669761;-0.691818;,
  -0.000000;0.026175;-0.999657;,
  -0.269828;-0.632638;-0.725922;,
  -0.382683;-0.923563;-0.024185;,
  -0.269828;-0.669762;0.691817;,
  -0.000000;-0.026178;0.999657;,
  0.269828;0.632636;0.725924;,
  0.707107;0.706865;0.018508;,
  0.498577;0.516969;-0.695819;,
  -0.000000;0.026177;-0.999657;,
  -0.498577;-0.479845;-0.721921;,
  -0.707106;-0.706865;-0.018511;,
  -0.498577;-0.516969;0.695819;,
  -0.000000;-0.026178;0.999657;,
  0.498577;0.479844;0.721921;,
  0.923879;0.382553;0.010017;,
  0.651422;0.288298;-0.701807;,
  0.000000;0.026177;-0.999657;,
  -0.651423;-0.251173;-0.715933;,
  -0.923879;-0.382553;-0.010018;,
  -0.651423;-0.288298;0.701807;,
  -0.000000;-0.026177;0.999657;,
  0.651423;0.251174;0.715933;,
  1.000000;0.000000;-0.000000;,
  0.705095;0.018563;-0.708870;,
  0.000000;0.026177;-0.999657;,
  -0.705095;0.018562;-0.708870;,
  -1.000000;-0.000000;-0.000000;,
  -0.705095;-0.018563;0.708870;,
  0.000000;-0.026177;0.999657;,
  0.705095;-0.018562;0.708870;,
  0.923880;-0.382552;-0.010017;,
  0.651423;-0.251173;-0.715933;,
  0.000000;0.026177;-0.999657;,
  -0.651422;0.288298;-0.701807;,
  -0.923880;0.382552;0.010017;,
  -0.651423;0.251173;0.715933;,
  0.000000;-0.026177;0.999657;,
  0.651423;-0.288298;0.701807;,
  0.707107;-0.706865;-0.018509;,
  0.498578;-0.479844;-0.721921;,
  0.000000;0.026177;-0.999657;,
  -0.498577;0.516969;-0.695819;,
  -0.707106;0.706865;0.018510;,
  -0.498577;0.479844;0.721921;,
  -0.000000;-0.026177;0.999657;,
  0.498577;-0.516969;0.695819;,
  0.382683;-0.923563;-0.024184;,
  0.269828;-0.632636;-0.725924;,
  -0.000000;0.026178;-0.999657;,
  -0.269828;0.669762;-0.691818;,
  -0.382683;0.923563;0.024185;,
  -0.269828;0.632638;0.725922;,
  0.000000;-0.026176;0.999657;,
  0.269828;-0.669761;0.691818;,
  -0.000000;-0.999657;-0.026177;,
  -0.000000;-0.686289;-0.727329;,
  -0.000000;0.026178;-0.999657;,
  -0.000000;0.723416;-0.690413;,
  0.000000;0.999657;0.026178;,
  0.000000;0.686292;0.727327;,
  -0.000000;-0.026174;0.999657;,
  -0.000000;-0.723415;0.690414;,
  -0.382683;-0.923563;-0.024184;,
  -0.269828;-0.632636;-0.725924;,
  0.000000;0.026178;-0.999657;,
  0.269828;0.669762;-0.691818;,
  0.382683;0.923563;0.024185;,
  0.269828;0.632638;0.725922;,
  -0.000000;-0.026176;0.999657;,
  -0.269828;-0.669761;0.691818;,
  -0.707107;-0.706865;-0.018509;,
  -0.498578;-0.479844;-0.721921;,
  -0.000000;0.026177;-0.999657;,
  0.498577;0.516969;-0.695819;,
  0.707107;0.706865;0.018510;,
  0.498577;0.479844;0.721921;,
  0.000000;-0.026177;0.999657;,
  -0.498577;-0.516969;0.695819;,
  -0.923880;-0.382552;-0.010017;,
  -0.651423;-0.251173;-0.715933;,
  -0.000000;0.026177;-0.999657;,
  0.651422;0.288298;-0.701807;,
  0.923880;0.382552;0.010018;,
  0.651423;0.251173;0.715933;,
  0.000000;-0.026177;0.999657;,
  -0.651423;-0.288298;0.701807;;
  128;
  4;0,1,9,8;,
  4;1,2,10,9;,
  4;2,3,11,10;,
  4;3,4,12,11;,
  4;4,5,13,12;,
  4;5,6,14,13;,
  4;6,7,15,14;,
  4;7,0,8,15;,
  4;8,9,17,16;,
  4;9,10,18,17;,
  4;10,11,19,18;,
  4;11,12,20,19;,
  4;12,13,21,20;,
  4;13,14,22,21;,
  4;14,15,23,22;,
  4;15,8,16,23;,
  4;16,17,25,24;,
  4;17,18,26,25;,
  4;18,19,27,26;,
  4;19,20,28,27;,
  4;20,21,29,28;,
  4;21,22,30,29;,
  4;22,23,31,30;,
  4;23,16,24,31;,
  4;24,25,33,32;,
  4;25,26,34,33;,
  4;26,27,35,34;,
  4;27,28,36,35;,
  4;28,29,37,36;,
  4;29,30,38,37;,
  4;30,31,39,38;,
  4;31,24,32,39;,
  4;32,33,41,40;,
  4;33,34,42,41;,
  4;34,35,43,42;,
  4;35,36,44,43;,
  4;36,37,45,44;,
  4;37,38,46,45;,
  4;38,39,47,46;,
  4;39,32,40,47;,
  4;40,41,49,48;,
  4;41,42,50,49;,
  4;42,43,51,50;,
  4;43,44,52,51;,
  4;44,45,53,52;,
  4;45,46,54,53;,
  4;46,47,55,54;,
  4;47,40,48,55;,
  4;48,49,57,56;,
  4;49,50,58,57;,
  4;50,51,59,58;,
  4;51,52,60,59;,
  4;52,53,61,60;,
  4;53,54,62,61;,
  4;54,55,63,62;,
  4;55,48,56,63;,
  4;56,57,65,64;,
  4;57,58,66,65;,
  4;58,59,67,66;,
  4;59,60,68,67;,
  4;60,61,69,68;,
  4;61,62,70,69;,
  4;62,63,71,70;,
  4;63,56,64,71;,
  4;64,65,73,72;,
  4;65,66,74,73;,
  4;66,67,75,74;,
  4;67,68,76,75;,
  4;68,69,77,76;,
  4;69,70,78,77;,
  4;70,71,79,78;,
  4;71,64,72,79;,
  4;72,73,81,80;,
  4;73,74,82,81;,
  4;74,75,83,82;,
  4;75,76,84,83;,
  4;76,77,85,84;,
  4;77,78,86,85;,
  4;78,79,87,86;,
  4;79,72,80,87;,
  4;80,81,89,88;,
  4;81,82,90,89;,
  4;82,83,91,90;,
  4;83,84,92,91;,
  4;84,85,93,92;,
  4;85,86,94,93;,
  4;86,87,95,94;,
  4;87,80,88,95;,
  4;88,89,97,96;,
  4;89,90,98,97;,
  4;90,91,99,98;,
  4;91,92,100,99;,
  4;92,93,101,100;,
  4;93,94,102,101;,
  4;94,95,103,102;,
  4;95,88,96,103;,
  4;96,97,105,104;,
  4;97,98,106,105;,
  4;98,99,107,106;,
  4;99,100,108,107;,
  4;100,101,109,108;,
  4;101,102,110,109;,
  4;102,103,111,110;,
  4;103,96,104,111;,
  4;104,105,113,112;,
  4;105,106,114,113;,
  4;106,107,115,114;,
  4;107,108,116,115;,
  4;108,109,117,116;,
  4;109,110,118,117;,
  4;110,111,119,118;,
  4;111,104,112,119;,
  4;112,113,121,120;,
  4;113,114,122,121;,
  4;114,115,123,122;,
  4;115,116,124,123;,
  4;116,117,125,124;,
  4;117,118,126,125;,
  4;118,119,127,126;,
  4;119,112,120,127;,
  4;120,121,1,0;,
  4;121,122,2,1;,
  4;122,123,3,2;,
  4;123,124,4,3;,
  4;124,125,5,4;,
  4;125,126,6,5;,
  4;126,127,7,6;,
  4;127,120,0,7;;
 }
 MeshTextureCoords {
  153;
  0.000000;0.000000;,
  0.000000;0.125000;,
  0.062500;0.125000;,
  0.062500;0.000000;,
  0.000000;0.250000;,
  0.062500;0.250000;,
  0.000000;0.375000;,
  0.062500;0.375000;,
  0.000000;0.500000;,
  0.062500;0.500000;,
  0.000000;0.625000;,
  0.062500;0.625000;,
  0.000000;0.750000;,
  0.062500;0.750000;,
  0.000000;0.875000;,
  0.062500;0.875000;,
  0.000000;1.000000;,
  0.062500;1.000000;,
  0.125000;0.125000;,
  0.125000;0.000000;,
  0.125000;0.250000;,
  0.125000;0.375000;,
  0.125000;0.500000;,
  0.125000;0.625000;,
  0.125000;0.750000;,
  0.125000;0.875000;,
  0.125000;1.000000;,
  0.187500;0.125000;,
  0.187500;0.000000;,
  0.187500;0.250000;,
  0.187500;0.375000;,
  0.187500;0.500000;,
  0.187500;0.625000;,
  0.187500;0.750000;,
  0.187500;0.875000;,
  0.187500;1.000000;,
  0.250000;0.125000;,
  0.250000;0.000000;,
  0.250000;0.250000;,
  0.250000;0.375000;,
  0.250000;0.500000;,
  0.250000;0.625000;,
  0.250000;0.750000;,
  0.250000;0.875000;,
  0.250000;1.000000;,
  0.312500;0.125000;,
  0.312500;0.000000;,
  0.312500;0.250000;,
  0.312500;0.375000;,
  0.312500;0.500000;,
  0.312500;0.625000;,
  0.312500;0.750000;,
  0.312500;0.875000;,
  0.312500;1.000000;,
  0.375000;0.125000;,
  0.375000;0.000000;,
  0.375000;0.250000;,
  0.375000;0.375000;,
  0.375000;0.500000;,
  0.375000;0.625000;,
  0.375000;0.750000;,
  0.375000;0.875000;,
  0.375000;1.000000;,
  0.437500;0.125000;,
  0.437500;0.000000;,
  0.437500;0.250000;,
  0.437500;0.375000;,
  0.437500;0.500000;,
  0.437500;0.625000;,
  0.437500;0.750000;,
  0.437500;0.875000;,
  0.437500;1.000000;,
  0.500000;0.125000;,
  0.500000;0.000000;,
  0.500000;0.250000;,
  0.500000;0.375000;,
  0.500000;0.500000;,
  0.500000;0.625000;,
  0.500000;0.750000;,
  0.500000;0.875000;,
  0.500000;1.000000;,
  0.562500;0.125000;,
  0.562500;0.000000;,
  0.562500;0.250000;,
  0.562500;0.375000;,
  0.562500;0.500000;,
  0.562500;0.625000;,
  0.562500;0.750000;,
  0.562500;0.875000;,
  0.562500;1.000000;,
  0.625000;0.125000;,
  0.625000;0.000000;,
  0.625000;0.250000;,
  0.625000;0.375000;,
  0.625000;0.500000;,
  0.625000;0.625000;,
  0.625000;0.750000;,
  0.625000;0.875000;,
  0.625000;1.000000;,
  0.687500;0.125000;,
  0.687500;0.000000;,
  0.687500;0.250000;,
  0.687500;0.375000;,
  0.687500;0.500000;,
  0.687500;0.625000;,
  0.687500;0.750000;,
  0.687500;0.875000;,
  0.687500;1.000000;,
  0.750000;0.125000;,
  0.750000;0.000000;,
  0.750000;0.250000;,
  0.750000;0.375000;,
  0.750000;0.500000;,
  0.750000;0.625000;,
  0.750000;0.750000;,
  0.750000;0.875000;,
  0.750000;1.000000;,
  0.812500;0.125000;,
  0.812500;0.000000;,
  0.812500;0.250000;,
  0.812500;0.375000;,
  0.812500;0.500000;,
  0.812500;0.625000;,
  0.812500;0.750000;,
  0.812500;0.875000;,
  0.812500;1.000000;,
  0.875000;0.125000;,
  0.875000;0.000000;,
  0.875000;0.250000;,
  0.875000;0.375000;,
  0.875000;0.500000;,
  0.875000;0.625000;,
  0.875000;0.750000;,
  0.875000;0.875000;,
  0.875000;1.000000;,
  0.937500;0.125000;,
  0.937500;0.000000;,
  0.937500;0.250000;,
  0.937500;0.375000;,
  0.937500;0.500000;,
  0.937500;0.625000;,
  0.937500;0.750000;,
  0.937500;0.875000;,
  0.937500;1.000000;,
  1.000000;0.125000;,
  1.000000;0.000000;,
  1.000000;0.250000;,
  1.000000;0.375000;,
  1.000000;0.500000;,
  1.000000;0.625000;,
  1.000000;0.750000;,
  1.000000;0.875000;,
  1.000000;1.000000;;
 }
 MeshVertexColors {
  153;
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
  121;1.000000;1.000000;1.000000;1.000000;,
  122;1.000000;1.000000;1.000000;1.000000;,
  123;1.000000;1.000000;1.000000;1.000000;,
  124;1.000000;1.000000;1.000000;1.000000;,
  125;1.000000;1.000000;1.000000;1.000000;,
  126;1.000000;1.000000;1.000000;1.000000;,
  127;1.000000;1.000000;1.000000;1.000000;,
  128;1.000000;1.000000;1.000000;1.000000;,
  129;1.000000;1.000000;1.000000;1.000000;,
  130;1.000000;1.000000;1.000000;1.000000;,
  131;1.000000;1.000000;1.000000;1.000000;,
  132;1.000000;1.000000;1.000000;1.000000;,
  133;1.000000;1.000000;1.000000;1.000000;,
  134;1.000000;1.000000;1.000000;1.000000;,
  135;1.000000;1.000000;1.000000;1.000000;,
  136;1.000000;1.000000;1.000000;1.000000;,
  137;1.000000;1.000000;1.000000;1.000000;,
  138;1.000000;1.000000;1.000000;1.000000;,
  139;1.000000;1.000000;1.000000;1.000000;,
  140;1.000000;1.000000;1.000000;1.000000;,
  141;1.000000;1.000000;1.000000;1.000000;,
  142;1.000000;1.000000;1.000000;1.000000;,
  143;1.000000;1.000000;1.000000;1.000000;,
  144;1.000000;1.000000;1.000000;1.000000;,
  145;1.000000;1.000000;1.000000;1.000000;,
  146;1.000000;1.000000;1.000000;1.000000;,
  147;1.000000;1.000000;1.000000;1.000000;,
  148;1.000000;1.000000;1.000000;1.000000;,
  149;1.000000;1.000000;1.000000;1.000000;,
  150;1.000000;1.000000;1.000000;1.000000;,
  151;1.000000;1.000000;1.000000;1.000000;,
  152;1.000000;1.000000;1.000000;1.000000;;
 }
}
