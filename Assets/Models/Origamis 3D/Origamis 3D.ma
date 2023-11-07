//Maya ASCII 2023 scene
//Name: Origamis 3D.ma
//Last modified: Tue, Nov 07, 2023 03:52:53 AM
//Codeset: 1252
requires maya "2023";
requires -nodeType "aiOptions" -nodeType "aiAOVDriver" -nodeType "aiAOVFilter" "mtoa" "5.2.1.1";
currentUnit -l centimeter -a degree -t film;
fileInfo "application" "maya";
fileInfo "product" "Maya 2023";
fileInfo "version" "2023";
fileInfo "cutIdentifier" "202211021031-847a9f9623";
fileInfo "osv" "Windows 11 Pro v2009 (Build: 22621)";
fileInfo "UUID" "E2576B81-4F56-F4A9-04FD-069541961437";
createNode transform -s -n "persp";
	rename -uid "723EB863-48C9-C9F6-DC18-B0B991A2C59D";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 26.407410033727565 15.64928803264165 5.1339997714965282 ;
	setAttr ".r" -type "double3" -28.800000000000161 -1717.5999999998373 1.2024200401008046e-14 ;
	setAttr ".rpt" -type "double3" -2.8227638161219857e-18 -4.4993956789293888e-17 -3.2448195891425912e-16 ;
createNode camera -s -n "perspShape" -p "persp";
	rename -uid "AC29002B-4ED3-B4E4-AC3B-04AF06D947E0";
	setAttr -k off ".v" no;
	setAttr ".fl" 34.999999999999979;
	setAttr ".coi" 29.096467792130863;
	setAttr ".imn" -type "string" "persp";
	setAttr ".den" -type "string" "persp_depth";
	setAttr ".man" -type "string" "persp_mask";
	setAttr ".tp" -type "double3" 9.5169874141524904 0.23721494674682653 1.9830691575950574 ;
	setAttr ".hc" -type "string" "viewSet -p %camera";
createNode transform -s -n "top";
	rename -uid "C8C51B57-4696-8F7A-C546-269DEA513111";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 5.2629161548567982 1000.3372149467471 5.2376494440989028 ;
	setAttr ".r" -type "double3" -90 89.999999999999972 0 ;
	setAttr ".rpt" -type "double3" -1.3561670910635956e-16 1.0097419586828951e-28 6.6554306042887804e-17 ;
createNode camera -s -n "topShape" -p "top";
	rename -uid "70C6FEB6-4BA0-1B32-DFBF-67899A9533CD";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1000000000003;
	setAttr ".ow" 6.7546124957568594;
	setAttr ".imn" -type "string" "top";
	setAttr ".den" -type "string" "top_depth";
	setAttr ".man" -type "string" "top_mask";
	setAttr ".tp" -type "double3" 9.5169874141524353 0.23721494674680343 1.9830691575950572 ;
	setAttr ".hc" -type "string" "viewSet -t %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "front";
	rename -uid "416B6DF8-4D63-10EC-F451-BE8193DDDFA4";
	setAttr ".v" no;
	setAttr ".t" -type "double3" -5.9029604555609305 -0.14507463970730794 1000.1 ;
createNode camera -s -n "frontShape" -p "front";
	rename -uid "14A2CF7A-4D3F-0C45-5090-75AE494F6444";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 5.7817574651930776;
	setAttr ".imn" -type "string" "front";
	setAttr ".den" -type "string" "front_depth";
	setAttr ".man" -type "string" "front_mask";
	setAttr ".hc" -type "string" "viewSet -f %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -s -n "side";
	rename -uid "3816C132-47E6-2B32-2032-4095ECE8BCFE";
	setAttr ".v" no;
	setAttr ".t" -type "double3" 1000.1 0 0 ;
	setAttr ".r" -type "double3" 0 90 0 ;
createNode camera -s -n "sideShape" -p "side";
	rename -uid "288A5475-4FC6-A622-A3F2-BAA732ACC7C5";
	setAttr -k off ".v" no;
	setAttr ".rnd" no;
	setAttr ".coi" 1000.1;
	setAttr ".ow" 30;
	setAttr ".imn" -type "string" "side";
	setAttr ".den" -type "string" "side_depth";
	setAttr ".man" -type "string" "side_mask";
	setAttr ".hc" -type "string" "viewSet -s %camera";
	setAttr ".o" yes;
	setAttr ".ai_translator" -type "string" "orthographic";
createNode transform -n "pCube1";
	rename -uid "6489EE78-4F10-4B40-4032-4AAC28288118";
	setAttr ".t" -type "double3" 17.548327433577089 0 10.667860668702973 ;
	setAttr ".s" -type "double3" 5.7752187034287878 0.1 1 ;
createNode mesh -n "pCubeShape1" -p "pCube1";
	rename -uid "71A73F8E-4D32-E539-C65F-E188DCC8BF6B";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr ".pv" -type "double2" 0.5 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 8 ".pt";
	setAttr ".pt[12]" -type "float3" 0 4.7683716e-07 0 ;
	setAttr ".pt[13]" -type "float3" 0 4.7683716e-07 0 ;
	setAttr ".pt[16]" -type "float3" 0 4.7683716e-07 0 ;
	setAttr ".pt[17]" -type "float3" 0 4.7683716e-07 0 ;
	setAttr ".pt[30]" -type "float3" 0 4.7683716e-07 0 ;
	setAttr ".pt[31]" -type "float3" 0 4.7683716e-07 0 ;
	setAttr ".pt[34]" -type "float3" 0 4.7683716e-07 0 ;
	setAttr ".pt[35]" -type "float3" 0 4.7683716e-07 0 ;
createNode transform -n "Escalera_de_Papel";
	rename -uid "52A1B019-4523-B93E-5E32-C68474FB64BB";
	setAttr ".t" -type "double3" 1.1265354917614161 2.3717515100576758 0.30778206600985225 ;
	setAttr ".s" -type "double3" 4.0407004916597336 4.0407004916597336 4.0407004916597336 ;
createNode mesh -n "Escalera_de_PapelShape" -p "Escalera_de_Papel";
	rename -uid "975A72AC-4A9B-B62C-462C-248F3332B345";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr -s 6 ".gtag";
	setAttr ".gtag[0].gtagnm" -type "string" "back";
	setAttr ".gtag[0].gtagcmp" -type "componentList" 4 "f[1]" "f[18]" "f[22:24]" "f[33:34]";
	setAttr ".gtag[1].gtagnm" -type "string" "bottom";
	setAttr ".gtag[1].gtagcmp" -type "componentList" 4 "f[2]" "f[7:10]" "f[19:21]" "f[46:53]";
	setAttr ".gtag[2].gtagnm" -type "string" "front";
	setAttr ".gtag[2].gtagcmp" -type "componentList" 6 "f[0]" "f[4:6]" "f[15:17]" "f[26:29]" "f[35:37]" "f[41]";
	setAttr ".gtag[3].gtagnm" -type "string" "left";
	setAttr ".gtag[3].gtagcmp" -type "componentList" 6 "f[3]" "f[12:14]" "f[30:32]" "f[38:40]" "f[42:45]" "f[53]";
	setAttr ".gtag[4].gtagnm" -type "string" "right";
	setAttr ".gtag[4].gtagcmp" -type "componentList" 0;
	setAttr ".gtag[5].gtagnm" -type "string" "top";
	setAttr ".gtag[5].gtagcmp" -type "componentList" 0;
	setAttr ".pv" -type "double2" 0.30174230474187591 0.49999997159466147 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 86 ".uvst[0].uvsp[0:85]" -type "float2" 0.11412599 0.52205336
		 0.57017159 0.42193463 0.57018155 0.55015421 0.093140692 0.41752765 0.96588928 0.55012369
		 0.9658795 0.421904 0.48569643 0.54036415 0.51714218 0.42373136 0.96909654 0.8597213
		 0.47133252 0.0080852332 0.12238961 -0.0011503072 0.074098483 0.14760734 0.96016669
		 0.27246779 0.57586133 0.27249745 0.096138783 0.81820005 0.96015674 0.14424819 0.48483765
		 0.59050071 0.11160692 0.57134295 0.12020745 0.5465253 0.47795805 0.56574225 0.11099716
		 0.3121202 0.49291682 0.30643004 0.51354349 0.13845456 0.46701387 0.020177033 0.12774281
		 0.01019852 0.084429786 0.15639399 0.49183542 0.25595534 0.10979881 0.26212591 0.084989652
		 0.68685049 0.10454924 0.79216951 0.11092769 0.81662744 0.46044502 0.83692425 0.46583563
		 0.85998589 0.10371649 0.84009653 0.46858475 0.81206578 0.49995393 0.69646043 0.5670104
		 0.70601982 0.56702036 0.8342393 0.11748231 0.28653118 0.48543864 0.28181532 0.9690944
		 0.83420831 0.9690845 0.70598876 0.96909535 0.84709185 0.064382218 0.15440042 0.96589148
		 0.57837462 0.96589029 0.56214792 0.57018369 0.57840526 0.57018256 0.56217855 0.57586229
		 0.2845217 0.57586324 0.29791692 0.52023447 0.698322 0.96016866 0.29788721 0.48177475
		 1.0011502504 0.064618304 0.9730649 0.076589972 0.97648543 0.48197588 0.98897201 0.4749845
		 0.83980268 0.57585144 0.14427792 0.51125294 0.70466411 0.10404529 0.54983395 0.074535355
		 0.68000513 0.51106304 0.69083184 0.49384949 0.57040393 0.96016765 0.28449199 0.064575799
		 0.68699878 0.078196883 0.4257414 0.072890222 0.69370383 0.070947282 0.41898862 0.53147626
		 0.43307683 0.53910238 0.42607149 0.52803081 0.41742739 0.082107648 0.41150177 0.10333938
		 0.28772321 0.49962676 0.28175402 0.52535474 0.14420611 0.56702125 0.84712291 0.07288985
		 0.1625618 0.53326011 0.13494797 0.56702226 0.8597523 0.52314395 0.12878427 0.56875181
		 0.99999613 0.96738857 0.99996537 0.49420077 0.98669839 0.57049537 3.4404919e-05 0.076398328
		 0.98867494 0.9654904 3.8500875e-06;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 56 ".pt[0:55]" -type "float3"  2.9802322e-08 2.9802322e-08 
		0 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 2.9802322e-08 
		0 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 2.9802322e-08 
		0 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 2.9802322e-08 
		0 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 2.9802322e-08 
		0 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 
		5.9604645e-08 -5.9604645e-08 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 
		5.9604645e-08 -5.9604645e-08 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 
		5.9604645e-08 -5.9604645e-08 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 2.9802322e-08 
		0 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 
		2.9802322e-08 0 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 5.9604645e-08 
		-5.9604645e-08 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 5.9604645e-08 
		-5.9604645e-08 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 2.9802322e-08 
		0 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 
		5.9604645e-08 -5.9604645e-08 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 
		5.9604645e-08 -5.9604645e-08 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 2.9802322e-08 
		0 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 5.9604645e-08 -5.9604645e-08 
		2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 5.9604645e-08 -5.9604645e-08 
		2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 5.9604645e-08 -5.9604645e-08 
		2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 
		2.9802322e-08 0 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 2.9802322e-08 
		0 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 5.9604645e-08 -5.9604645e-08 
		2.9802322e-08 2.9802322e-08 0 2.9802322e-08 5.9604645e-08 -5.9604645e-08 2.9802322e-08 
		5.9604645e-08 -5.9604645e-08 2.9802322e-08 2.9802322e-08 0 2.9802322e-08 2.9802322e-08 
		0;
	setAttr -s 56 ".vt[0:55]"  0.16666663 -0.49999961 0.47782728 0.5 -0.49999961 0.4737421
		 -0.16666648 -0.16666633 0.47026137 0.16666663 -0.16666633 0.47782728 -0.49999997 0.16666672 0.45671073
		 -0.16666648 0.16666672 0.47026137 -0.49999997 0.5 0.45671073 -0.49999997 0.5 -0.45671073
		 -0.49999997 0.16666672 -0.45671073 -0.16666648 0.16666672 -0.47026139 -0.16666648 -0.16666645 -0.47026139
		 0.16666663 -0.16666645 -0.47782728 0.16666663 -0.49999961 -0.47782728 0.5 -0.49999961 -0.4737421
		 0.16666663 -0.53062129 -0.47782734 0.16666663 -0.53062129 0.47782722 0.5 -0.53062129 -0.47374216
		 0.5 -0.53062129 0.47374204 -0.53183794 0.16666675 0.45671067 -0.53183794 0.16666675 -0.45671079
		 -0.56214547 0.5 0.45671073 -0.56214547 0.5 -0.45671073 0.13664892 -0.49999958 0.47782722
		 0.099999934 -0.16666633 0.47782728 0.099999934 -0.16666645 -0.47782728 0.13664892 -0.49999958 -0.47782734
		 0.13664892 -0.53062129 -0.47782734 0.13664892 -0.53062129 0.47782722 -0.16666648 -0.19524592 -0.47026145
		 0.13664892 -0.19524592 -0.47782734 0.16666663 -0.23333308 -0.47782728 0.16666663 -0.23333308 0.47782728
		 0.13664892 -0.19524592 0.47782722 -0.16666648 -0.19524592 0.47026131 -0.20523429 -0.19524592 -0.47026145
		 -0.20523429 -0.16666642 -0.47026145 -0.23333308 0.16666672 -0.47026139 -0.23333308 0.16666672 0.47026137
		 -0.20523429 -0.1666663 0.47026131 -0.20523429 -0.19524592 0.47026131 -0.49999997 0.13808745 0.45671067
		 -0.53183794 0.13808745 0.45671067 -0.53183794 0.13808745 -0.45671079 -0.49999997 0.13808745 -0.45671079
		 -0.20523429 0.13808745 -0.47026145 -0.16666648 0.10000029 -0.47026139 -0.16666648 0.10000029 0.47026137
		 -0.20523429 0.13808745 0.47026131 -0.49999997 0.43333343 0.45671073 -0.53183794 0.47142047 0.45671067
		 -0.53183794 0.47142047 -0.45671079 -0.49999997 0.43333343 -0.45671073 -0.87467861 0.47142047 0.4694142
		 -0.87467861 0.47142047 -0.46941435 -0.87467861 0.5 0.46941426 -0.87467861 0.5 -0.46941429;
	setAttr -s 108 ".ed[0:107]"  0 1 0 2 23 0 10 24 0 12 13 0 0 31 0 2 46 0
		 4 48 0 6 7 0 7 51 0 8 43 0 9 45 0 10 28 1 11 30 0 13 1 0 5 9 0 4 8 0 3 11 0 2 10 0
		 12 14 0 0 15 0 14 15 1 13 16 0 14 16 0 1 17 0 16 17 0 15 17 0 12 0 0 4 18 0 8 19 0
		 19 18 1 19 42 0 6 20 0 18 49 0 7 21 0 20 21 0 21 50 0 22 0 0 23 3 0 24 11 0 25 12 0
		 26 14 0 27 15 0 22 32 0 23 24 1 24 29 1 25 26 0 26 27 0 27 22 0 29 25 0 30 12 0 31 3 0
		 32 23 1 33 2 1 28 29 0 29 30 1 30 31 1 31 32 1 32 33 0 33 39 0 4 37 0 8 36 0 34 28 0
		 35 10 1 36 9 0 37 5 0 38 2 1 34 35 0 35 44 0 36 37 1 37 47 1 38 39 0 40 4 0 41 18 0
		 44 36 1 45 10 0 46 5 0 47 38 0 40 41 0 41 42 0 42 43 0 43 44 0 44 45 1 45 46 1 46 47 1
		 47 40 0 48 6 0 49 20 0 50 19 0 51 8 0 48 49 1 49 50 0 50 51 1 51 48 1 49 52 0 50 53 0
		 52 53 0 20 54 0 52 54 0 21 55 0 54 55 0 55 53 0 29 32 0 25 22 1 28 33 0 34 39 0 35 38 0
		 44 47 0 43 40 0;
	setAttr -s 54 -ch 216 ".fc[0:53]" -type "polyFaces" 
		f 4 83 76 65 5
		mu 0 4 0 59 65 3
		f 4 67 81 74 -63
		mu 0 4 68 62 6 7
		f 4 22 24 -26 -21
		mu 0 4 8 81 80 78
		f 4 29 32 90 87
		mu 0 4 12 13 57 15
		f 4 68 64 14 -64
		mu 0 4 16 17 18 19
		f 4 1 43 -3 -18
		mu 0 4 3 20 21 7
		f 4 82 -6 17 -75
		mu 0 4 6 0 3 7
		f 4 3 21 -23 -19
		mu 0 4 22 23 9 79
		f 4 13 23 -25 -22
		mu 0 4 23 24 10 9
		f 4 -1 19 25 -24
		mu 0 4 24 25 11 10
		f 4 -14 -4 26 0
		mu 0 4 24 23 22 25
		f 4 55 -5 -27 -50
		mu 0 4 26 27 25 22
		f 4 6 89 -33 -28
		mu 0 4 28 29 14 66
		f 4 7 33 -35 -32
		mu 0 4 30 31 32 33
		f 4 91 88 28 -88
		mu 0 4 56 34 35 58
		f 4 92 -7 15 -89
		mu 0 4 34 29 28 35
		f 4 56 -43 36 4
		mu 0 4 27 72 76 25
		f 4 -44 37 16 -39
		mu 0 4 21 20 38 39
		f 4 -49 54 49 -40
		mu 0 4 74 73 26 22
		f 4 -46 39 18 -41
		mu 0 4 77 74 22 79
		f 4 -47 40 20 -42
		mu 0 4 75 42 8 78
		f 4 -37 -48 41 -20
		mu 0 4 25 76 43 11
		f 4 -62 66 62 11
		mu 0 4 70 69 68 7
		f 4 2 44 -54 -12
		mu 0 4 7 21 73 70
		f 4 -55 -45 38 12
		mu 0 4 26 73 21 39
		f 4 -17 -51 -56 -13
		mu 0 4 39 38 27 26
		f 4 -52 -57 50 -38
		mu 0 4 20 72 27 38
		f 4 -58 51 -2 -53
		mu 0 4 71 72 20 3
		f 4 70 -59 52 -66
		mu 0 4 65 67 71 3
		f 4 -16 59 -69 -61
		mu 0 4 35 28 17 16
		f 4 -78 71 27 -73
		mu 0 4 64 60 28 66
		f 4 -79 72 -30 30
		mu 0 4 63 48 13 12
		f 4 9 -80 -31 -29
		mu 0 4 35 61 50 58
		f 4 -81 -10 60 -74
		mu 0 4 62 61 35 16
		f 4 -82 73 63 10
		mu 0 4 6 62 16 19
		f 4 -15 -76 -83 -11
		mu 0 4 19 18 0 6
		f 4 69 -84 75 -65
		mu 0 4 17 59 0 18
		f 4 -72 -85 -70 -60
		mu 0 4 28 60 59 17
		f 4 -90 85 31 -87
		mu 0 4 14 29 30 33
		f 4 -96 97 99 100
		mu 0 4 52 84 54 55
		f 4 8 -92 -36 -34
		mu 0 4 31 34 56 32
		f 4 -8 -86 -93 -9
		mu 0 4 31 30 29 34
		f 4 -91 93 95 -95
		mu 0 4 15 57 83 85
		f 4 86 96 -98 -94
		mu 0 4 14 33 54 53
		f 4 34 98 -100 -97
		mu 0 4 33 32 55 54
		f 4 35 94 -101 -99
		mu 0 4 32 56 82 55
		f 4 102 42 -102 48
		mu 0 4 40 37 36 41
		f 4 46 47 -103 45
		mu 0 4 42 75 37 40
		f 4 101 57 -104 53
		mu 0 4 41 36 46 44
		f 4 103 58 -105 61
		mu 0 4 44 46 47 45
		f 4 104 -71 -106 -67
		mu 0 4 45 47 2 4
		f 4 105 -77 -107 -68
		mu 0 4 4 2 1 5
		f 4 106 84 -108 80
		mu 0 4 5 1 49 51
		f 4 78 79 107 77
		mu 0 4 48 63 51 49;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 7 
		0 0 
		6 0 
		10 0 
		44 0 
		47 0 
		52 0 
		53 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "Avion_de_Papel";
	rename -uid "7FA3B40C-4DDE-1B79-EA8A-C49D4C08A7E4";
	setAttr ".t" -type "double3" -0.25951300383449794 0.084876170937491446 -6.6486433535187732 ;
	setAttr ".s" -type "double3" 5.7752187034287878 0.1 1 ;
	setAttr ".rp" -type "double3" 0 0.050000095367431587 0.5 ;
	setAttr ".sp" -type "double3" 0 0.50000095367431641 0.5 ;
	setAttr ".spt" -type "double3" 0 -0.4500008583068848 0 ;
createNode mesh -n "Avion_de_PapelShape" -p "Avion_de_Papel";
	rename -uid "E6712E11-4AF1-0210-2977-44AA23E39716";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr -s 6 ".gtag";
	setAttr ".gtag[0].gtagnm" -type "string" "back";
	setAttr ".gtag[0].gtagcmp" -type "componentList" 3 "f[1]" "f[10]" "f[23:24]";
	setAttr ".gtag[1].gtagnm" -type "string" "bottom";
	setAttr ".gtag[1].gtagcmp" -type "componentList" 2 "f[2]" "f[11]";
	setAttr ".gtag[2].gtagnm" -type "string" "front";
	setAttr ".gtag[2].gtagcmp" -type "componentList" 0;
	setAttr ".gtag[3].gtagnm" -type "string" "left";
	setAttr ".gtag[3].gtagcmp" -type "componentList" 0;
	setAttr ".gtag[4].gtagnm" -type "string" "right";
	setAttr ".gtag[4].gtagcmp" -type "componentList" 2 "f[3]" "f[12]";
	setAttr ".gtag[5].gtagnm" -type "string" "top";
	setAttr ".gtag[5].gtagcmp" -type "componentList" 4 "f[0]" "f[4:9]" "f[13:22]" "f[25:29]";
	setAttr ".pv" -type "double2" 0.49999997019767761 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 34 ".uvst[0].uvsp[0:33]" -type "float2" 0.50095123 0.75453341
		 0.49841857 0.44428083 0.52462429 0.44419485 0.51198345 0.73434156 0.51571637 0.740385
		 0.79715389 0.68348587 0.19836563 0.71802723 0.50104147 0.76811284 0.003986299 0.63518977
		 0.99247563 0.59346551 0.53696787 0.23188716 0.49602902 0.23240206 0.74478614 0.45016739
		 0.83221388 0.35478616 0.83451331 0.36340749 0.74596238 0.45842206 0.77735645 0.66652811
		 0.48973542 0.73453927 0.47220549 0.44553375 0.48599502 0.74056298 0.20402509 0.68866521
		 0.45522526 0.23366028 0.0067301393 0.60350233 0.25166142 0.45448074 0.25054514 0.4627367
		 0.16032037 0.36968136 0.16236773 0.36100525 0.22344598 0.67136145 0.80321652 0.71295244
		 0.99643981 0.62459487 -5.9604645e-08 0.59799272 1 0.61570877 5.7607889e-05 0.62618601
		 0.99906176 0.58779943;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 28 ".vt[0:27]"  -0.49999991 -0.49999622 0.5 0.49999973 -0.49999812 0.5
		 -0.49999991 0.64585477 0.5 0.49999973 0.64585263 0.5 -0.49999991 3.51283383 0.34580135
		 0.49999973 3.51283383 0.34580135 -0.49999991 2.51283383 0.32655621 0.49999973 2.51283383 0.32655621
		 0.17904125 3.90676951 -2.41833878 0.49999973 3.90676951 -2.41833878 0.49999973 2.90676975 -2.41833878
		 0.17904113 2.90676975 -2.41833878 -0.49999991 3.51283383 0.65419865 0.49999973 3.51283383 0.65419865
		 -0.49999991 2.51283383 0.67344379 0.49999973 2.51283383 0.67344379 0.17904125 3.90676951 3.41833806
		 0.49999973 3.90676951 3.41833806 0.49999973 2.90676975 3.41833806 0.17904113 2.90676975 3.41833806
		 0.099999905 3.51283383 0.65419865 0.099999905 0.64585334 0.5 0.099999905 3.51283383 0.34580135
		 0.099999905 2.51283383 0.32655621 0.099999905 -0.49999741 0.5 0.099999905 2.51283383 0.67344379
		 0.099999905 -0.087061107 0.16247225 0.099999905 -0.087061107 0.83752775;
	setAttr -s 56 ".ed[0:55]"  0 24 0 2 21 0 4 22 0 6 23 0 0 2 1 1 3 1 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 4 8 0 5 9 0 8 9 0 7 10 0 9 10 0 6 11 0 11 10 0 8 11 0
		 3 13 0 12 20 0 2 12 0 14 25 0 15 1 0 14 0 0 13 15 0 12 14 0 16 17 0 17 18 0 19 18 0
		 16 19 0 13 17 0 12 16 0 15 18 0 14 19 0 20 13 0 21 3 0 22 5 0 23 7 0 24 1 0 25 15 0
		 16 20 1 20 21 1 21 22 1 22 8 1 11 23 0 23 24 1 24 25 1 25 19 0 23 26 0 11 26 0 6 26 0
		 25 27 0 27 19 0 14 27 0;
	setAttr -s 30 -ch 112 ".fc[0:29]" -type "polyFaces" 
		f 4 1 44 -3 -7
		mu 0 4 0 1 2 3
		f 4 3 47 -1 -11
		mu 0 4 4 5 28 7
		f 4 -12 -10 -8 -6
		mu 0 4 29 9 33 31
		f 4 10 4 6 8
		mu 0 4 4 7 0 3
		f 4 14 16 -19 -20
		mu 0 4 12 13 14 15
		f 3 2 45 -13
		mu 0 3 3 2 12
		f 4 9 15 -17 -14
		mu 0 4 33 9 14 13
		f 3 51 -53 17
		mu 0 3 15 16 4
		f 4 -9 12 19 -18
		mu 0 4 4 3 12 15
		f 4 22 21 43 -2
		mu 0 4 0 17 18 1
		f 4 25 0 48 -24
		mu 0 4 19 7 6 20
		f 4 5 20 26 24
		mu 0 4 8 32 30 22
		f 4 -28 -23 -5 -26
		mu 0 4 19 17 0 7
		f 4 31 30 -30 -29
		mu 0 4 23 24 25 26
		f 3 33 42 -22
		mu 0 3 17 23 18
		f 4 32 29 -35 -27
		mu 0 4 30 26 25 22
		f 3 54 -36 55
		mu 0 3 27 24 19
		f 4 35 -32 -34 27
		mu 0 4 19 24 23 17
		f 4 -43 28 -33 -37
		mu 0 4 18 23 26 21
		f 4 -44 36 -21 -38
		mu 0 4 1 18 21 11
		f 4 -45 37 7 -39
		mu 0 4 2 1 11 10
		f 4 -46 38 13 -15
		mu 0 4 12 2 10 13
		f 4 -40 -47 18 -16
		mu 0 4 9 5 15 14
		f 4 -48 39 11 -41
		mu 0 4 28 5 9 29
		f 4 -49 40 -25 -42
		mu 0 4 20 6 8 22
		f 4 34 -31 -50 41
		mu 0 4 22 25 24 20
		f 3 46 50 -52
		mu 0 3 15 5 16
		f 3 -4 52 -51
		mu 0 3 5 4 16
		f 3 49 -55 -54
		mu 0 3 20 24 27
		f 3 23 53 -56
		mu 0 3 19 20 27;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 4 
		4 0 
		5 0 
		6 0 
		7 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode mesh -n "polySurfaceShape1" -p "Avion_de_Papel";
	rename -uid "F56BB1A2-4819-56BB-30F8-69913D4C9E7D";
	setAttr -k off ".v";
	setAttr ".io" yes;
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr -s 6 ".gtag";
	setAttr ".gtag[0].gtagnm" -type "string" "back";
	setAttr ".gtag[0].gtagcmp" -type "componentList" 3 "f[1]" "f[5:19]" "f[21]";
	setAttr ".gtag[1].gtagnm" -type "string" "bottom";
	setAttr ".gtag[1].gtagcmp" -type "componentList" 2 "f[2]" "f[22]";
	setAttr ".gtag[2].gtagnm" -type "string" "front";
	setAttr ".gtag[2].gtagcmp" -type "componentList" 0;
	setAttr ".gtag[3].gtagnm" -type "string" "left";
	setAttr ".gtag[3].gtagcmp" -type "componentList" 1 "f[4]";
	setAttr ".gtag[4].gtagnm" -type "string" "right";
	setAttr ".gtag[4].gtagcmp" -type "componentList" 2 "f[3]" "f[23]";
	setAttr ".gtag[5].gtagnm" -type "string" "top";
	setAttr ".gtag[5].gtagcmp" -type "componentList" 2 "f[0]" "f[20]";
	setAttr ".pv" -type "double2" 0.5 0.625 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 42 ".uvst[0].uvsp[0:41]" -type "float2" 0.375 0 0.625 0 0.375
		 0.25 0.625 0.25 0.375 0.5 0.625 0.5 0.375 0.75 0.625 0.75 0.375 1 0.625 1 0.875 0
		 0.875 0.25 0.125 0 0.125 0.25 0.375 0.25 0.625 0.25 0.625 0.5 0.375 0.5 0.375 0.5
		 0.625 0.5 0.625 0.75 0.375 0.75 0.375 0.75 0.625 0.75 0.625 1 0.375 1 0.625 0 0.875
		 0 0.875 0.25 0.125 0 0.375 0 0.125 0.25 0.375 0.5 0.625 0.5 0.625 0.5 0.375 0.5 0.625
		 0.5 0.375 0.5 0.62499774 0.5 0.37500232 0.5 0.625 0.5 0.375 0.5;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 26 ".vt[0:25]"  -0.5 -0.49999622 0.5 0.5 -0.49999809 0.5
		 -0.5 0.50000191 0.5 0.5 0.5 0.5 -0.5 0.49999905 -0.5 0.5 0.49999905 -0.5 -0.5 -0.50000095 -0.5
		 0.5 -0.50000095 -0.5 -0.5 0.49999905 1.5 0.5 0.49999905 1.5 -0.5 -0.50000095 1.5
		 0.5 -0.50000095 1.5 -0.5 0.5 1.63337755 0.5 0.5 1.63337755 0.5 -0.5 1.63337755 -0.5 -0.5 1.63337755
		 -0.5 14.83095646 1.79395223 0.5 14.83095646 1.79395223 0.5 14.83095741 1.92732978
		 -0.5 14.83095741 1.92732978 -0.5 15.76081181 2.024760485 0.5 15.76081181 2.024760485
		 -0.5 6.012598991 2.75272846 0.5 6.012598991 2.75272846 0.5 4.97540665 2.66887188
		 -0.5 4.97540665 2.66887188;
	setAttr -s 49 ".ed[0:48]"  0 1 1 2 3 1 4 5 0 6 7 0 0 2 1 1 3 1 2 4 0
		 3 5 0 4 6 0 5 7 0 6 0 0 7 1 0 3 9 0 8 9 0 2 8 0 12 13 0 13 14 0 15 14 0 12 15 0 10 11 0
		 11 1 0 10 0 0 9 11 0 8 10 0 22 23 0 23 24 0 25 24 0 22 25 0 11 14 0 9 13 0 10 15 0
		 8 12 0 9 17 0 16 17 0 8 16 0 13 18 0 17 18 0 12 19 0 19 18 0 16 19 0 17 21 0 20 21 0
		 16 20 0 21 18 0 20 19 0 21 23 0 20 22 0 18 24 0 19 25 0;
	setAttr -s 24 -ch 94 ".fc[0:23]" -type "polyFaces" 
		f 4 1 7 -3 -7
		mu 0 4 2 3 5 4
		f 4 3 11 -1 -11
		mu 0 4 6 7 9 8
		f 4 -12 -10 -8 -6
		mu 0 4 1 10 11 3
		f 4 10 4 6 8
		mu 0 4 12 0 2 13
		f 4 14 13 -13 -2
		mu 0 4 14 17 16 15
		f 4 18 17 -17 -16
		mu 0 4 18 21 20 19
		f 4 21 0 -21 -20
		mu 0 4 22 25 24 23
		f 4 5 12 22 20
		mu 0 4 26 15 28 27
		f 4 -24 -15 -5 -22
		mu 0 4 29 31 14 30
		f 4 27 26 -26 -25
		mu 0 4 32 35 34 33
		f 4 29 16 -29 -23
		mu 0 4 16 19 20 23
		f 4 28 -18 -31 19
		mu 0 4 23 20 21 22
		f 4 30 -19 -32 23
		mu 0 4 22 21 18 17
		f 4 34 33 -33 -14
		mu 0 4 17 37 36 16
		f 4 32 36 -36 -30
		mu 0 4 16 36 38 19
		f 4 35 -39 -38 15
		mu 0 4 19 38 39 18
		f 4 37 -40 -35 31
		mu 0 4 18 39 37 17
		f 4 42 41 -41 -34
		mu 0 4 37 41 40 36
		f 3 40 43 -37
		mu 0 3 36 40 38
		f 3 -45 -43 39
		mu 0 3 39 41 37
		f 4 46 24 -46 -42
		mu 0 4 41 32 33 40
		f 4 45 25 -48 -44
		mu 0 4 40 33 34 38
		f 4 47 -27 -49 38
		mu 0 4 38 34 35 39
		f 4 48 -28 -47 44
		mu 0 4 39 35 32 41;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode transform -n "Puente_de_Papel";
	rename -uid "80B65264-407A-CE59-FCC1-428EED6C1910";
	setAttr ".t" -type "double3" -0.11985002569461134 0.80613247681066857 5.9446901053101406 ;
	setAttr ".s" -type "double3" 7.770373265714154 0.12743172103913872 1 ;
createNode mesh -n "Puente_de_PapelShape" -p "Puente_de_Papel";
	rename -uid "6EFDBE43-4B15-E806-4412-D397D9C81F10";
	setAttr -k off ".v";
	setAttr ".vir" yes;
	setAttr ".vif" yes;
	setAttr -s 6 ".gtag";
	setAttr ".gtag[0].gtagnm" -type "string" "back";
	setAttr ".gtag[0].gtagcmp" -type "componentList" 1 "f[2]";
	setAttr ".gtag[1].gtagnm" -type "string" "bottom";
	setAttr ".gtag[1].gtagcmp" -type "componentList" 4 "f[3]" "f[7]" "f[11]" "f[17]";
	setAttr ".gtag[2].gtagnm" -type "string" "front";
	setAttr ".gtag[2].gtagcmp" -type "componentList" 1 "f[0]";
	setAttr ".gtag[3].gtagnm" -type "string" "left";
	setAttr ".gtag[3].gtagcmp" -type "componentList" 3 "f[5:6]" "f[10]" "f[14]";
	setAttr ".gtag[4].gtagnm" -type "string" "right";
	setAttr ".gtag[4].gtagcmp" -type "componentList" 4 "f[4]" "f[8]" "f[12]" "f[16]";
	setAttr ".gtag[5].gtagnm" -type "string" "top";
	setAttr ".gtag[5].gtagcmp" -type "componentList" 4 "f[1]" "f[9]" "f[13]" "f[15]";
	setAttr ".pv" -type "double2" 0.49999998509883881 0.5 ;
	setAttr ".uvst[0].uvsn" -type "string" "map1";
	setAttr -s 32 ".uvst[0].uvsp[0:31]" -type "float2" 0.83568043 1 0.17294699
		 0.011609226 0.17340526 0.99725366 0.82554841 0.99752235 0.18514594 0.88175189 0.81379437
		 0.88590896 0.82684219 0.51291668 0.17420396 0.51321089 0.16406795 0.51073778 0.8268342
		 0.50218421 0.82632446 0.12506604 0.17567092 0.88225532 0.82671982 0.38772309 0.81497777
		 0.62855911 0.1738309 0.38830209 0.18608186 0.6246835 0.83780044 0.75298202 0.84755564
		 0.75287992 0.17348978 0.25713664 0.1621995 0.75746965 0.17659289 0.62443036 0.15244433
		 0.75757188 0.82445252 0.62805605 0.82654101 0.25637317 0.1731863 0.1259284 0.16326365
		 0.99993992 0.82328361 0.88616174 0.82611096 0.010717601 0.17416951 0.5025084 0.83698773
		 0.51022595 0.17292562 0.0008918047 0.8260898 0;
	setAttr ".cuvs" -type "string" "map1";
	setAttr ".dcc" -type "string" "Ambient+Diffuse";
	setAttr ".covm[0]"  0 1 1;
	setAttr ".cdvm[0]"  0 1 1;
	setAttr -s 20 ".vt[0:19]"  -0.50000006 -0.5 2.6276021 0.50000006 -0.5 2.6276021
		 -0.50000006 0.5 2.6276021 0.50000006 0.5 2.6276021 -0.50000006 0.5 -2.62760139 0.50000006 0.5 -2.62760139
		 -0.50000006 -0.5 -2.62760139 0.50000006 -0.5 -2.62760139 -0.50000006 -0.69079924 0
		 -0.50000006 -1.69079971 0 0.50000006 -1.69079971 0 0.50000006 -0.69079924 0 -0.50000006 4.894907 1.38888884
		 -0.50000006 3.894907 1.38888884 0.50000006 3.894907 1.38888884 0.50000006 4.894907 1.38888884
		 -0.50000006 3.894907 -1.38888931 -0.50000006 4.894907 -1.38888931 0.50000006 4.894907 -1.38888931
		 0.50000006 3.894907 -1.38888931;
	setAttr -s 36 ".ed[0:35]"  0 1 0 2 3 0 4 5 0 6 7 0 0 2 0 1 3 0 2 12 0
		 3 15 0 4 6 0 5 7 0 6 16 0 7 19 0 8 17 0 9 13 0 10 14 0 11 18 0 8 9 1 9 10 0 10 11 1
		 11 8 0 12 8 0 13 0 0 14 1 0 15 11 0 12 13 1 13 14 0 14 15 1 15 12 0 16 9 0 17 4 0
		 18 5 0 19 10 0 16 17 1 17 18 0 18 19 1 19 16 0;
	setAttr -s 18 -ch 72 ".fc[0:17]" -type "polyFaces" 
		f 4 0 5 -2 -5
		mu 0 4 27 1 30 31
		f 4 1 7 27 -7
		mu 0 4 3 2 4 5
		f 4 2 9 -4 -9
		mu 0 4 6 7 28 9
		f 4 25 22 -1 -22
		mu 0 4 10 24 1 27
		f 4 -23 26 -8 -6
		mu 0 4 25 11 4 2
		f 4 24 21 4 6
		mu 0 4 5 26 0 3
		f 4 10 32 29 8
		mu 0 4 29 22 13 6
		f 4 3 11 35 -11
		mu 0 4 9 28 14 12
		f 4 34 -12 -10 -31
		mu 0 4 15 20 8 7
		f 4 33 30 -3 -30
		mu 0 4 13 15 7 6
		f 4 16 13 -25 20
		mu 0 4 16 17 26 5
		f 4 17 14 -26 -14
		mu 0 4 23 18 24 10
		f 4 -27 -15 18 -24
		mu 0 4 4 11 21 19
		f 4 -28 23 19 -21
		mu 0 4 5 4 19 16
		f 4 -33 28 -17 12
		mu 0 4 13 22 17 16
		f 4 -20 15 -34 -13
		mu 0 4 16 19 15 13
		f 4 -19 -32 -35 -16
		mu 0 4 19 21 20 15
		f 4 -36 31 -18 -29
		mu 0 4 12 14 18 23;
	setAttr ".cd" -type "dataPolyComponent" Index_Data Edge 0 ;
	setAttr ".cvd" -type "dataPolyComponent" Index_Data Vertex 0 ;
	setAttr ".pd[0]" -type "dataPolyComponent" Index_Data UV 0 ;
	setAttr ".hfd" -type "dataPolyComponent" Index_Data Face 0 ;
createNode lightLinker -s -n "lightLinker1";
	rename -uid "950C696D-40BE-14B3-8F9B-D1A1726C891F";
	setAttr -s 2 ".lnk";
	setAttr -s 2 ".slnk";
createNode shapeEditorManager -n "shapeEditorManager";
	rename -uid "8538F87F-4B44-D639-5CFF-35BF4309E7F9";
createNode poseInterpolatorManager -n "poseInterpolatorManager";
	rename -uid "A6E0F5CB-4CDE-4833-60A7-7EAFB53820EA";
createNode displayLayerManager -n "layerManager";
	rename -uid "BB3F4002-414C-4274-81FC-D280F29EC1EC";
createNode displayLayer -n "defaultLayer";
	rename -uid "C3B98E7E-417F-485D-0932-9EBDD2FDC471";
	setAttr ".ufem" -type "stringArray" 0  ;
createNode renderLayerManager -n "renderLayerManager";
	rename -uid "A652BE38-4C12-6B00-76D2-92952E50C1BA";
createNode renderLayer -n "defaultRenderLayer";
	rename -uid "C1C2195E-4A04-10B0-E977-3B91B2A0911B";
	setAttr ".g" yes;
createNode aiOptions -s -n "defaultArnoldRenderOptions";
	rename -uid "8191196A-45ED-3D61-1E29-96A80CCD988C";
	setAttr ".version" -type "string" "5.2.1.1";
createNode aiAOVFilter -s -n "defaultArnoldFilter";
	rename -uid "4F71EA30-413C-75C5-9D33-E095B712920D";
	setAttr ".ai_translator" -type "string" "gaussian";
createNode aiAOVDriver -s -n "defaultArnoldDriver";
	rename -uid "B6D9E7C1-4F40-D24A-2C76-68A34839BCFF";
	setAttr ".ai_translator" -type "string" "exr";
createNode aiAOVDriver -s -n "defaultArnoldDisplayDriver";
	rename -uid "FE449331-4691-DED5-1098-FFA8569326B8";
	setAttr ".output_mode" 0;
	setAttr ".ai_translator" -type "string" "maya";
createNode polyCube -n "polyCube1";
	rename -uid "15C29BEE-4B14-7C1D-D2E5-1E83E0EDEB37";
	setAttr ".cuv" 4;
createNode polyMirror -n "polyMirror1";
	rename -uid "113A8C1F-436B-F19B-03E2-7FB7BB5B419F";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ix" -type "matrix" 10 0 0 0 0 0.10000000000000001 0 0 0 0 1 0 0 0 -0.5 1;
	setAttr ".ws" yes;
	setAttr ".a" 2;
	setAttr ".ad" 0;
	setAttr ".mtt" 1;
	setAttr ".mt" 2;
	setAttr ".cm" yes;
	setAttr ".fnf" 5;
	setAttr ".lnf" 9;
createNode polyExtrudeFace -n "polyExtrudeFace1";
	rename -uid "DC33802F-4F94-D529-FC08-0A8CB79F4000";
	setAttr ".ics" -type "componentList" 2 "f[1]" "f[6]";
	setAttr ".ix" -type "matrix" 10 0 0 0 0 0.10000000000000001 0 0 0 0 1 0 0 0 -0.5 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 -9.5367433e-08 0 ;
	setAttr ".rs" 54760;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -5 -0.050000095367431642 -1 ;
	setAttr ".cbx" -type "double3" 5 0.049999904632568364 1 ;
	setAttr ".raf" no;
createNode polyExtrudeFace -n "polyExtrudeFace2";
	rename -uid "064E309C-4499-C4B3-FC12-0DB4CFCD5E01";
	setAttr ".ics" -type "componentList" 2 "f[10]" "f[17]";
	setAttr ".ix" -type "matrix" 10 0 0 0 0 0.10000000000000001 0 0 0 0 1 0 0 0 -0.5 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 0.049999952 0 ;
	setAttr ".rs" 49951;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -5 0.049999904632568364 -1.1333775520324707 ;
	setAttr ".cbx" -type "double3" 5 0.05 1.1333775520324707 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak1";
	rename -uid "D2C316BD-46D4-1D60-C177-4D88D7FDE31C";
	setAttr ".uopa" yes;
	setAttr -s 19 ".tk";
	setAttr ".tk[0]" -type "float3" 0 3.8146973e-06 4.7683716e-07 ;
	setAttr ".tk[1]" -type "float3" 0 1.9073486e-06 0 ;
	setAttr ".tk[2]" -type "float3" 0 1.9073486e-06 4.7683716e-07 ;
	setAttr ".tk[4]" -type "float3" 0 -9.5367432e-07 0 ;
	setAttr ".tk[5]" -type "float3" 0 -9.5367432e-07 0 ;
	setAttr ".tk[6]" -type "float3" 0 -9.5367432e-07 0 ;
	setAttr ".tk[7]" -type "float3" 0 -9.5367432e-07 0 ;
	setAttr ".tk[8]" -type "float3" 0 -9.5367432e-07 0 ;
	setAttr ".tk[9]" -type "float3" 0 -9.5367432e-07 0 ;
	setAttr ".tk[10]" -type "float3" 0 -9.5367432e-07 0 ;
	setAttr ".tk[11]" -type "float3" 0 -9.5367432e-07 0 ;
	setAttr ".tk[12]" -type "float3" 0 0 -0.13337752 ;
	setAttr ".tk[13]" -type "float3" 0 0 -0.13337752 ;
	setAttr ".tk[14]" -type "float3" 0 0 -0.13337752 ;
	setAttr ".tk[15]" -type "float3" 0 0 -0.13337752 ;
	setAttr ".tk[16]" -type "float3" 0 0 0.13337752 ;
	setAttr ".tk[17]" -type "float3" 0 0 0.13337752 ;
	setAttr ".tk[18]" -type "float3" 0 0 0.13337752 ;
	setAttr ".tk[19]" -type "float3" 0 0 0.13337752 ;
createNode polyExtrudeFace -n "polyExtrudeFace3";
	rename -uid "B36B3F5C-434F-3EBB-3E7D-E4B3802E0C0A";
	setAttr ".ics" -type "componentList" 1 "f[10]";
	setAttr ".ix" -type "matrix" 10 0 0 0 0 0.10000000000000001 0 0 0 0 1 0 0 0 -0.5 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 1.4830956 -1.360641 ;
	setAttr ".rs" 64156;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -5 1.483095645904541 -1.4273297786712646 ;
	setAttr ".cbx" -type "double3" 5 1.4830957412719727 -1.2939522266387939 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak2";
	rename -uid "50D6639F-4838-0590-7993-0294A0119427";
	setAttr ".uopa" yes;
	setAttr -s 10 ".tk";
	setAttr ".tk[20]" -type "float3" 0 14.330957 -0.29395226 ;
	setAttr ".tk[21]" -type "float3" 0 14.330957 -0.29395226 ;
	setAttr ".tk[22]" -type "float3" 0 14.330957 -0.29395226 ;
	setAttr ".tk[23]" -type "float3" 0 14.330957 -0.29395226 ;
	setAttr ".tk[24]" -type "float3" 0 14.330957 0 ;
	setAttr ".tk[25]" -type "float3" 0 14.330957 0 ;
	setAttr ".tk[26]" -type "float3" 0 14.330957 0 ;
	setAttr ".tk[27]" -type "float3" 0 14.330957 0 ;
createNode polyExtrudeFace -n "polyExtrudeFace4";
	rename -uid "48A3FE44-49CD-4221-60B2-E1A3653241DB";
	setAttr ".ics" -type "componentList" 1 "f[10]";
	setAttr ".ix" -type "matrix" 10 0 0 0 0 0.10000000000000001 0 0 0 0 1 0 0 0 -0.5 1;
	setAttr ".ws" yes;
	setAttr ".pvt" -type "float3" 0 1.5242215 -1.4828322 ;
	setAttr ".rs" 35663;
	setAttr ".c[0]"  0 1 1;
	setAttr ".cbn" -type "double3" -5 1.4723619461059572 -1.5247604846954346 ;
	setAttr ".cbx" -type "double3" 5 1.5760810852050782 -1.4409040212631226 ;
	setAttr ".raf" no;
createNode polyTweak -n "polyTweak3";
	rename -uid "9262644B-4880-7E6B-C060-8389F611B08F";
	setAttr ".uopa" yes;
	setAttr -s 5 ".tk";
	setAttr ".tk[28]" -type "float3" 0 0.92985433 -0.23080827 ;
	setAttr ".tk[29]" -type "float3" 0 0.92985433 -0.23080827 ;
	setAttr ".tk[30]" -type "float3" 0 -0.10733815 -0.013574269 ;
	setAttr ".tk[31]" -type "float3" 0 -0.10733815 -0.013574269 ;
createNode polyTweak -n "polyTweak4";
	rename -uid "8A0B6E87-4693-402E-9321-108ED7D4056B";
	setAttr ".uopa" yes;
	setAttr -s 6 ".tk";
	setAttr ".tk[32]" -type "float3" -5.5511151e-17 -9.7482128 -0.72796792 ;
	setAttr ".tk[33]" -type "float3" 5.5511151e-16 -9.7482128 -0.72796792 ;
	setAttr ".tk[34]" -type "float3" 5.5511151e-16 -9.7482128 -0.72796792 ;
	setAttr ".tk[35]" -type "float3" -5.5511151e-17 -9.7482128 -0.72796792 ;
createNode deleteComponent -n "deleteComponent1";
	rename -uid "B927A817-4578-114A-8501-5ABCF29FAFB4";
	setAttr ".dc" -type "componentList" 1 "f[28]";
createNode polyTweakUV -n "polyTweakUV1";
	rename -uid "FD37492A-406C-8029-7568-378B3336BF24";
	setAttr ".uopa" yes;
	setAttr -s 5 ".uvtk";
	setAttr ".uvtk[38]" -type "float2" -2.2424824e-06 9.7699626e-15 ;
	setAttr ".uvtk[39]" -type "float2" 2.3628356e-06 9.7699626e-15 ;
	setAttr ".uvtk[46]" -type "float2" -2.1963988e-06 0 ;
	setAttr ".uvtk[47]" -type "float2" 2.2690645e-06 5.7287508e-14 ;
createNode polyMergeVert -n "polyMergeVert1";
	rename -uid "85E49A35-47EB-CA38-7C8F-3E826F25DF1D";
	setAttr ".ics" -type "componentList" 2 "vtx[22:23]" "vtx[30:31]";
	setAttr ".ix" -type "matrix" 10 0 0 0 0 0.10000000000000001 0 0 0 0 1 0 0 0 -0.5 1;
	setAttr ".d" 1e-06;
createNode polyTweak -n "polyTweak5";
	rename -uid "334F9604-4347-8C3B-039E-FD8356ABA12A";
	setAttr ".uopa" yes;
	setAttr -s 4 ".tk";
	setAttr ".tk[30]" -type "float3" 0 0.10733795 0.013574243 ;
	setAttr ".tk[31]" -type "float3" 0 0.10733795 0.013574243 ;
createNode polyMirror -n "polyMirror2";
	rename -uid "2BA9B879-4770-8177-C789-5CBABF712DB8";
	setAttr ".uopa" yes;
	setAttr ".ics" -type "componentList" 1 "f[*]";
	setAttr ".ix" -type "matrix" 10 0 0 0 0 0.10000000000000001 0 0 0 0 1 0 0 0 -0.5 1;
	setAttr ".ws" yes;
	setAttr ".a" 2;
	setAttr ".ad" 0;
	setAttr ".mtt" 1;
	setAttr ".mt" 15.514483451843262;
	setAttr ".cm" yes;
	setAttr ".fnf" 20;
	setAttr ".lnf" 39;
createNode script -n "uiConfigurationScriptNode";
	rename -uid "C4A53E83-45B2-CDE7-9C18-4892EFF90B48";
	setAttr ".b" -type "string" (
		"// Maya Mel UI Configuration File.\n//\n//  This script is machine generated.  Edit at your own risk.\n//\n//\n\nglobal string $gMainPane;\nif (`paneLayout -exists $gMainPane`) {\n\n\tglobal int $gUseScenePanelConfig;\n\tint    $useSceneConfig = $gUseScenePanelConfig;\n\tint    $nodeEditorPanelVisible = stringArrayContains(\"nodeEditorPanel1\", `getPanel -vis`);\n\tint    $nodeEditorWorkspaceControlOpen = (`workspaceControl -exists nodeEditorPanel1Window` && `workspaceControl -q -visible nodeEditorPanel1Window`);\n\tint    $menusOkayInPanels = `optionVar -q allowMenusInPanels`;\n\tint    $nVisPanes = `paneLayout -q -nvp $gMainPane`;\n\tint    $nPanes = 0;\n\tstring $editorName;\n\tstring $panelName;\n\tstring $itemFilterName;\n\tstring $panelConfig;\n\n\t//\n\t//  get current state of the UI\n\t//\n\tsceneUIReplacement -update $gMainPane;\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Top View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Top View\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|top\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n"
		+ "            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n"
		+ "            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -bluePencil 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 224\n            -height 383\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n"
		+ "\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Side View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Side View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|side\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n"
		+ "            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n"
		+ "            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -bluePencil 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n"
		+ "            -width 224\n            -height 383\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Front View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Front View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|front\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n"
		+ "            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n"
		+ "            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n"
		+ "            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -bluePencil 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 224\n            -height 383\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"modelPanel\" (localizedPanelLabel(\"Persp View\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tmodelPanel -edit -l (localizedPanelLabel(\"Persp View\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        modelEditor -e \n            -camera \"|persp\" \n            -useInteractiveMode 0\n            -displayLights \"default\" \n"
		+ "            -displayAppearance \"smoothShaded\" \n            -activeOnly 0\n            -ignorePanZoom 0\n            -wireframeOnShaded 0\n            -headsUpDisplay 1\n            -holdOuts 1\n            -selectionHiliteDisplay 1\n            -useDefaultMaterial 0\n            -bufferMode \"double\" \n            -twoSidedLighting 0\n            -backfaceCulling 0\n            -xray 0\n            -jointXray 0\n            -activeComponentsXray 0\n            -displayTextures 0\n            -smoothWireframe 0\n            -lineWidth 1\n            -textureAnisotropic 0\n            -textureHilight 1\n            -textureSampling 2\n            -textureDisplay \"modulate\" \n            -textureMaxSize 16384\n            -fogging 0\n            -fogSource \"fragment\" \n            -fogMode \"linear\" \n            -fogStart 0\n            -fogEnd 100\n            -fogDensity 0.1\n            -fogColor 0.5 0.5 0.5 1 \n            -depthOfFieldPreview 1\n            -maxConstantTransparency 1\n            -rendererName \"vp2Renderer\" \n            -objectFilterShowInHUD 1\n"
		+ "            -isFiltered 0\n            -colorResolution 256 256 \n            -bumpResolution 512 512 \n            -textureCompression 0\n            -transparencyAlgorithm \"frontAndBackCull\" \n            -transpInShadows 0\n            -cullingOverride \"none\" \n            -lowQualityLighting 0\n            -maximumNumHardwareLights 1\n            -occlusionCulling 0\n            -shadingModel 0\n            -useBaseRenderer 0\n            -useReducedRenderer 0\n            -smallObjectCulling 0\n            -smallObjectThreshold -1 \n            -interactiveDisableShadows 0\n            -interactiveBackFaceCull 0\n            -sortTransparent 1\n            -controllers 1\n            -nurbsCurves 1\n            -nurbsSurfaces 1\n            -polymeshes 1\n            -subdivSurfaces 1\n            -planes 1\n            -lights 1\n            -cameras 1\n            -controlVertices 1\n            -hulls 1\n            -grid 1\n            -imagePlane 1\n            -joints 1\n            -ikHandles 1\n            -deformers 1\n            -dynamics 1\n"
		+ "            -particleInstancers 1\n            -fluids 1\n            -hairSystems 1\n            -follicles 1\n            -nCloths 1\n            -nParticles 1\n            -nRigids 1\n            -dynamicConstraints 1\n            -locators 1\n            -manipulators 1\n            -pluginShapes 1\n            -dimensions 1\n            -handles 1\n            -pivots 1\n            -textures 1\n            -strokes 1\n            -motionTrails 1\n            -clipGhosts 1\n            -bluePencil 1\n            -greasePencils 0\n            -shadows 0\n            -captureSequenceNumber -1\n            -width 614\n            -height 811\n            -sceneRenderFilter 0\n            $editorName;\n        modelEditor -e -viewSelected 0 $editorName;\n        modelEditor -e \n            -pluginObjects \"gpuCacheDisplayFilter\" 1 \n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"ToggledOutliner\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"ToggledOutliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 1\n            -showReferenceMembers 1\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n"
		+ "            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -isSet 0\n            -isSetMember 0\n            -showUfeItems 1\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n"
		+ "            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            -renderFilterIndex 0\n            -selectionOrder \"chronological\" \n            -expandAttribute 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"outlinerPanel\" (localizedPanelLabel(\"Outliner\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\toutlinerPanel -edit -l (localizedPanelLabel(\"Outliner\")) -mbv $menusOkayInPanels  $panelName;\n\t\t$editorName = $panelName;\n        outlinerEditor -e \n            -showShapes 0\n            -showAssignedMaterials 0\n            -showTimeEditor 1\n            -showReferenceNodes 0\n            -showReferenceMembers 0\n            -showAttributes 0\n            -showConnected 0\n            -showAnimCurvesOnly 0\n            -showMuteInfo 0\n            -organizeByLayer 1\n            -organizeByClip 1\n            -showAnimLayerWeight 1\n            -autoExpandLayers 1\n            -autoExpand 0\n"
		+ "            -showDagOnly 1\n            -showAssets 1\n            -showContainedOnly 1\n            -showPublishedAsConnected 0\n            -showParentContainers 0\n            -showContainerContents 1\n            -ignoreDagHierarchy 0\n            -expandConnections 0\n            -showUpstreamCurves 1\n            -showUnitlessCurves 1\n            -showCompounds 1\n            -showLeafs 1\n            -showNumericAttrsOnly 0\n            -highlightActive 1\n            -autoSelectNewObjects 0\n            -doNotSelectNewObjects 0\n            -dropIsParent 1\n            -transmitFilters 0\n            -setFilter \"defaultSetFilter\" \n            -showSetMembers 1\n            -allowMultiSelection 1\n            -alwaysToggleSelect 0\n            -directSelect 0\n            -showUfeItems 1\n            -displayMode \"DAG\" \n            -expandObjects 0\n            -setsIgnoreFilters 1\n            -containersIgnoreFilters 0\n            -editAttrName 0\n            -showAttrValues 0\n            -highlightSecondary 0\n            -showUVAttrsOnly 0\n"
		+ "            -showTextureNodesOnly 0\n            -attrAlphaOrder \"default\" \n            -animLayerFilterOptions \"allAffecting\" \n            -sortOrder \"none\" \n            -longNames 0\n            -niceNames 1\n            -showNamespace 1\n            -showPinIcons 0\n            -mapMotionTrails 0\n            -ignoreHiddenAttribute 0\n            -ignoreOutlinerColor 0\n            -renderFilterVisible 0\n            $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"graphEditor\" (localizedPanelLabel(\"Graph Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Graph Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n"
		+ "                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 1\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 1\n                -showCompounds 0\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n                -highlightActive 0\n                -autoSelectNewObjects 1\n                -doNotSelectNewObjects 0\n                -dropIsParent 1\n                -transmitFilters 1\n                -setFilter \"0\" \n                -showSetMembers 0\n"
		+ "                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -showUfeItems 1\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 1\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"GraphEd\");\n            animCurveEditor -e \n                -displayValues 0\n                -snapTime \"integer\" \n"
		+ "                -snapValue \"none\" \n                -showPlayRangeShades \"on\" \n                -lockPlayRangeShades \"off\" \n                -smoothness \"fine\" \n                -resultSamples 1\n                -resultScreenSamples 0\n                -resultUpdate \"delayed\" \n                -showUpstreamCurves 1\n                -keyMinScale 1\n                -stackedCurvesMin -1\n                -stackedCurvesMax 1\n                -stackedCurvesSpace 0.2\n                -preSelectionHighlight 0\n                -constrainDrag 0\n                -valueLinesToggle 1\n                -outliner \"graphEditor1OutlineEd\" \n                -highlightAffectedCurves 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dopeSheetPanel\" (localizedPanelLabel(\"Dope Sheet\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dope Sheet\")) -mbv $menusOkayInPanels  $panelName;\n"
		+ "\n\t\t\t$editorName = ($panelName+\"OutlineEd\");\n            outlinerEditor -e \n                -showShapes 1\n                -showAssignedMaterials 0\n                -showTimeEditor 1\n                -showReferenceNodes 0\n                -showReferenceMembers 0\n                -showAttributes 1\n                -showConnected 1\n                -showAnimCurvesOnly 1\n                -showMuteInfo 0\n                -organizeByLayer 1\n                -organizeByClip 1\n                -showAnimLayerWeight 1\n                -autoExpandLayers 1\n                -autoExpand 0\n                -showDagOnly 0\n                -showAssets 1\n                -showContainedOnly 0\n                -showPublishedAsConnected 0\n                -showParentContainers 0\n                -showContainerContents 0\n                -ignoreDagHierarchy 0\n                -expandConnections 1\n                -showUpstreamCurves 1\n                -showUnitlessCurves 0\n                -showCompounds 1\n                -showLeafs 1\n                -showNumericAttrsOnly 1\n"
		+ "                -highlightActive 0\n                -autoSelectNewObjects 0\n                -doNotSelectNewObjects 1\n                -dropIsParent 1\n                -transmitFilters 0\n                -setFilter \"0\" \n                -showSetMembers 0\n                -allowMultiSelection 1\n                -alwaysToggleSelect 0\n                -directSelect 0\n                -showUfeItems 1\n                -displayMode \"DAG\" \n                -expandObjects 0\n                -setsIgnoreFilters 1\n                -containersIgnoreFilters 0\n                -editAttrName 0\n                -showAttrValues 0\n                -highlightSecondary 0\n                -showUVAttrsOnly 0\n                -showTextureNodesOnly 0\n                -attrAlphaOrder \"default\" \n                -animLayerFilterOptions \"allAffecting\" \n                -sortOrder \"none\" \n                -longNames 0\n                -niceNames 1\n                -showNamespace 1\n                -showPinIcons 0\n                -mapMotionTrails 1\n                -ignoreHiddenAttribute 0\n"
		+ "                -ignoreOutlinerColor 0\n                -renderFilterVisible 0\n                $editorName;\n\n\t\t\t$editorName = ($panelName+\"DopeSheetEd\");\n            dopeSheetEditor -e \n                -displayValues 0\n                -snapTime \"integer\" \n                -snapValue \"none\" \n                -outliner \"dopeSheetPanel1OutlineEd\" \n                -showSummary 1\n                -showScene 0\n                -hierarchyBelow 0\n                -showTicks 1\n                -selectionWindow 0 0 0 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"timeEditorPanel\" (localizedPanelLabel(\"Time Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Time Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"clipEditorPanel\" (localizedPanelLabel(\"Trax Editor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Trax Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = clipEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayValues 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n                -manageSequencer 0 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"sequenceEditorPanel\" (localizedPanelLabel(\"Camera Sequencer\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Camera Sequencer\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = sequenceEditorNameFromPanel($panelName);\n            clipEditor -e \n                -displayValues 0\n                -snapTime \"none\" \n                -snapValue \"none\" \n                -initialized 0\n"
		+ "                -manageSequencer 1 \n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperGraphPanel\" (localizedPanelLabel(\"Hypergraph Hierarchy\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypergraph Hierarchy\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"HyperGraphEd\");\n            hyperGraph -e \n                -graphLayoutStyle \"hierarchicalLayout\" \n                -orientation \"horiz\" \n                -mergeConnections 0\n                -zoom 1\n                -animateTransition 0\n                -showRelationships 1\n                -showShapes 0\n                -showDeformers 0\n                -showExpressions 0\n                -showConstraints 0\n                -showConnectionFromSelected 0\n                -showConnectionToSelected 0\n                -showConstraintLabels 0\n                -showUnderworld 0\n"
		+ "                -showInvisible 0\n                -transitionFrames 1\n                -opaqueContainers 0\n                -freeform 0\n                -imagePosition 0 0 \n                -imageScale 1\n                -imageEnabled 0\n                -graphType \"DAG\" \n                -heatMapDisplay 0\n                -updateSelection 1\n                -updateNodeAdded 1\n                -useDrawOverrideColor 0\n                -limitGraphTraversal -1\n                -range 0 0 \n                -iconSize \"smallIcons\" \n                -showCachedConnections 0\n                $editorName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"hyperShadePanel\" (localizedPanelLabel(\"Hypershade\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Hypershade\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"visorPanel\" (localizedPanelLabel(\"Visor\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Visor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"nodeEditorPanel\" (localizedPanelLabel(\"Node Editor\")) `;\n\tif ($nodeEditorPanelVisible || $nodeEditorWorkspaceControlOpen) {\n\t\tif (\"\" == $panelName) {\n\t\t\tif ($useSceneConfig) {\n\t\t\t\t$panelName = `scriptedPanel -unParent  -type \"nodeEditorPanel\" -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels `;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n"
		+ "                -additiveGraphingMode 0\n                -connectedGraphingMode 1\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n                -extendToShapes 1\n                -showUnitConversions 0\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\t}\n\t\t} else {\n\t\t\t$label = `panel -q -label $panelName`;\n\t\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Node Editor\")) -mbv $menusOkayInPanels  $panelName;\n\n\t\t\t$editorName = ($panelName+\"NodeEditorEd\");\n            nodeEditor -e \n"
		+ "                -allAttributes 0\n                -allNodes 0\n                -autoSizeNodes 1\n                -consistentNameSize 1\n                -createNodeCommand \"nodeEdCreateNodeCommand\" \n                -connectNodeOnCreation 0\n                -connectOnDrop 0\n                -copyConnectionsOnPaste 0\n                -connectionStyle \"bezier\" \n                -defaultPinnedState 0\n                -additiveGraphingMode 0\n                -connectedGraphingMode 1\n                -settingsChangedCallback \"nodeEdSyncControls\" \n                -traversalDepthLimit -1\n                -keyPressCommand \"nodeEdKeyPressCommand\" \n                -nodeTitleMode \"name\" \n                -gridSnap 0\n                -gridVisibility 1\n                -crosshairOnEdgeDragging 0\n                -popupMenuScript \"nodeEdBuildPanelMenus\" \n                -showNamespace 1\n                -showShapes 1\n                -showSGShapes 0\n                -showTransforms 1\n                -useAssets 1\n                -syncedSelection 1\n"
		+ "                -extendToShapes 1\n                -showUnitConversions 0\n                -editorMode \"default\" \n                -hasWatchpoint 0\n                $editorName;\n\t\t\tif (!$useSceneConfig) {\n\t\t\t\tpanel -e -l $label $panelName;\n\t\t\t}\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"createNodePanel\" (localizedPanelLabel(\"Create Node\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Create Node\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"polyTexturePlacementPanel\" (localizedPanelLabel(\"UV Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"UV Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"renderWindowPanel\" (localizedPanelLabel(\"Render View\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Render View\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"shapePanel\" (localizedPanelLabel(\"Shape Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tshapePanel -edit -l (localizedPanelLabel(\"Shape Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextPanel \"posePanel\" (localizedPanelLabel(\"Pose Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tposePanel -edit -l (localizedPanelLabel(\"Pose Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynRelEdPanel\" (localizedPanelLabel(\"Dynamic Relationships\")) `;\n\tif (\"\" != $panelName) {\n"
		+ "\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Dynamic Relationships\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"relationshipPanel\" (localizedPanelLabel(\"Relationship Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Relationship Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"referenceEditorPanel\" (localizedPanelLabel(\"Reference Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Reference Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"dynPaintScriptedPanelType\" (localizedPanelLabel(\"Paint Effects\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Paint Effects\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"scriptEditorPanel\" (localizedPanelLabel(\"Script Editor\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Script Editor\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"profilerPanel\" (localizedPanelLabel(\"Profiler Tool\")) `;\n\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Profiler Tool\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\t$panelName = `sceneUIReplacement -getNextScriptedPanel \"contentBrowserPanel\" (localizedPanelLabel(\"Content Browser\")) `;\n"
		+ "\tif (\"\" != $panelName) {\n\t\t$label = `panel -q -label $panelName`;\n\t\tscriptedPanel -edit -l (localizedPanelLabel(\"Content Browser\")) -mbv $menusOkayInPanels  $panelName;\n\t\tif (!$useSceneConfig) {\n\t\t\tpanel -e -l $label $panelName;\n\t\t}\n\t}\n\n\n\tif ($useSceneConfig) {\n        string $configName = `getPanel -cwl (localizedPanelLabel(\"Current Layout\"))`;\n        if (\"\" != $configName) {\n\t\t\tpanelConfiguration -edit -label (localizedPanelLabel(\"Current Layout\")) \n\t\t\t\t-userCreated false\n\t\t\t\t-defaultImage \"vacantCell.xP:/\"\n\t\t\t\t-image \"\"\n\t\t\t\t-sc false\n\t\t\t\t-configString \"global string $gMainPane; paneLayout -e -cn \\\"single\\\" -ps 1 100 100 $gMainPane;\"\n\t\t\t\t-removeAllPanels\n\t\t\t\t-ap false\n\t\t\t\t\t(localizedPanelLabel(\"Persp View\")) \n\t\t\t\t\t\"modelPanel\"\n"
		+ "\t\t\t\t\t\"$panelName = `modelPanel -unParent -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels `;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -bluePencil 1\\n    -greasePencils 0\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 614\\n    -height 811\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t\t\"modelPanel -edit -l (localizedPanelLabel(\\\"Persp View\\\")) -mbv $menusOkayInPanels  $panelName;\\n$editorName = $panelName;\\nmodelEditor -e \\n    -cam `findStartUpCamera persp` \\n    -useInteractiveMode 0\\n    -displayLights \\\"default\\\" \\n    -displayAppearance \\\"smoothShaded\\\" \\n    -activeOnly 0\\n    -ignorePanZoom 0\\n    -wireframeOnShaded 0\\n    -headsUpDisplay 1\\n    -holdOuts 1\\n    -selectionHiliteDisplay 1\\n    -useDefaultMaterial 0\\n    -bufferMode \\\"double\\\" \\n    -twoSidedLighting 0\\n    -backfaceCulling 0\\n    -xray 0\\n    -jointXray 0\\n    -activeComponentsXray 0\\n    -displayTextures 0\\n    -smoothWireframe 0\\n    -lineWidth 1\\n    -textureAnisotropic 0\\n    -textureHilight 1\\n    -textureSampling 2\\n    -textureDisplay \\\"modulate\\\" \\n    -textureMaxSize 16384\\n    -fogging 0\\n    -fogSource \\\"fragment\\\" \\n    -fogMode \\\"linear\\\" \\n    -fogStart 0\\n    -fogEnd 100\\n    -fogDensity 0.1\\n    -fogColor 0.5 0.5 0.5 1 \\n    -depthOfFieldPreview 1\\n    -maxConstantTransparency 1\\n    -rendererName \\\"vp2Renderer\\\" \\n    -objectFilterShowInHUD 1\\n    -isFiltered 0\\n    -colorResolution 256 256 \\n    -bumpResolution 512 512 \\n    -textureCompression 0\\n    -transparencyAlgorithm \\\"frontAndBackCull\\\" \\n    -transpInShadows 0\\n    -cullingOverride \\\"none\\\" \\n    -lowQualityLighting 0\\n    -maximumNumHardwareLights 1\\n    -occlusionCulling 0\\n    -shadingModel 0\\n    -useBaseRenderer 0\\n    -useReducedRenderer 0\\n    -smallObjectCulling 0\\n    -smallObjectThreshold -1 \\n    -interactiveDisableShadows 0\\n    -interactiveBackFaceCull 0\\n    -sortTransparent 1\\n    -controllers 1\\n    -nurbsCurves 1\\n    -nurbsSurfaces 1\\n    -polymeshes 1\\n    -subdivSurfaces 1\\n    -planes 1\\n    -lights 1\\n    -cameras 1\\n    -controlVertices 1\\n    -hulls 1\\n    -grid 1\\n    -imagePlane 1\\n    -joints 1\\n    -ikHandles 1\\n    -deformers 1\\n    -dynamics 1\\n    -particleInstancers 1\\n    -fluids 1\\n    -hairSystems 1\\n    -follicles 1\\n    -nCloths 1\\n    -nParticles 1\\n    -nRigids 1\\n    -dynamicConstraints 1\\n    -locators 1\\n    -manipulators 1\\n    -pluginShapes 1\\n    -dimensions 1\\n    -handles 1\\n    -pivots 1\\n    -textures 1\\n    -strokes 1\\n    -motionTrails 1\\n    -clipGhosts 1\\n    -bluePencil 1\\n    -greasePencils 0\\n    -shadows 0\\n    -captureSequenceNumber -1\\n    -width 614\\n    -height 811\\n    -sceneRenderFilter 0\\n    $editorName;\\nmodelEditor -e -viewSelected 0 $editorName;\\nmodelEditor -e \\n    -pluginObjects \\\"gpuCacheDisplayFilter\\\" 1 \\n    $editorName\"\n"
		+ "\t\t\t\t$configName;\n\n            setNamedPanelLayout (localizedPanelLabel(\"Current Layout\"));\n        }\n\n        panelHistory -e -clear mainPanelHistory;\n        sceneUIReplacement -clear;\n\t}\n\n\ngrid -spacing 5 -size 12 -divisions 5 -displayAxes yes -displayGridLines yes -displayDivisionLines yes -displayPerspectiveLabels no -displayOrthographicLabels no -displayAxesBold yes -perspectiveLabelPosition axis -orthographicLabelPosition edge;\nviewManip -drawCompass 0 -compassAngle 0 -frontParameters \"\" -homeParameters \"\" -selectionLockParameters \"\";\n}\n");
	setAttr ".st" 3;
createNode script -n "sceneConfigurationScriptNode";
	rename -uid "96C9A67D-4C16-E0C2-07A8-968ECA652F00";
	setAttr ".b" -type "string" "playbackOptions -min 0 -max 75 -ast 0 -aet 202 ";
	setAttr ".st" 6;
select -ne :time1;
	setAttr ".o" 0;
select -ne :hardwareRenderingGlobals;
	setAttr ".otfna" -type "stringArray" 22 "NURBS Curves" "NURBS Surfaces" "Polygons" "Subdiv Surface" "Particles" "Particle Instance" "Fluids" "Strokes" "Image Planes" "UI" "Lights" "Cameras" "Locators" "Joints" "IK Handles" "Deformers" "Motion Trails" "Components" "Hair Systems" "Follicles" "Misc. UI" "Ornaments"  ;
	setAttr ".otfva" -type "Int32Array" 22 0 1 1 1 1 1
		 1 1 1 0 0 0 0 0 0 0 0 0
		 0 0 0 0 ;
	setAttr ".fprt" yes;
select -ne :renderPartition;
	setAttr -s 2 ".st";
select -ne :renderGlobalsList1;
select -ne :defaultShaderList1;
	setAttr -s 5 ".s";
select -ne :postProcessList1;
	setAttr -s 2 ".p";
select -ne :defaultRenderingList1;
select -ne :lambert1;
	setAttr ".ic" -type "float3" 0.22023809 0.22023809 0.22023809 ;
select -ne :initialShadingGroup;
	setAttr -s 4 ".dsm";
	setAttr ".ro" yes;
select -ne :initialParticleSE;
	setAttr ".ro" yes;
select -ne :defaultRenderGlobals;
	addAttr -ci true -h true -sn "dss" -ln "defaultSurfaceShader" -dt "string";
	setAttr ".ren" -type "string" "arnold";
	setAttr ".dss" -type "string" "lambert1";
select -ne :defaultResolution;
	setAttr ".pa" 1;
select -ne :defaultColorMgtGlobals;
	setAttr ".cfe" yes;
	setAttr ".cfp" -type "string" "<MAYA_RESOURCES>/OCIO-configs/Maya2022-default/config.ocio";
	setAttr ".vtn" -type "string" "ACES 1.0 SDR-video (sRGB)";
	setAttr ".vn" -type "string" "ACES 1.0 SDR-video";
	setAttr ".dn" -type "string" "sRGB";
	setAttr ".wsn" -type "string" "ACEScg";
	setAttr ".otn" -type "string" "ACES 1.0 SDR-video (sRGB)";
	setAttr ".potn" -type "string" "ACES 1.0 SDR-video (sRGB)";
select -ne :hardwareRenderGlobals;
	setAttr ".ctrs" 256;
	setAttr ".btrs" 512;
connectAttr "polyMirror2.out" "pCubeShape1.i";
connectAttr "polyTweakUV1.uvtk[0]" "pCubeShape1.uvst[0].uvtw";
relationship "link" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "link" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialShadingGroup.message" ":defaultLightSet.message";
relationship "shadowLink" ":lightLinker1" ":initialParticleSE.message" ":defaultLightSet.message";
connectAttr "layerManager.dli[0]" "defaultLayer.id";
connectAttr "renderLayerManager.rlmi[0]" "defaultRenderLayer.rlid";
connectAttr ":defaultArnoldDisplayDriver.msg" ":defaultArnoldRenderOptions.drivers"
		 -na;
connectAttr ":defaultArnoldFilter.msg" ":defaultArnoldRenderOptions.filt";
connectAttr ":defaultArnoldDriver.msg" ":defaultArnoldRenderOptions.drvr";
connectAttr "polyCube1.out" "polyMirror1.ip";
connectAttr "pCubeShape1.wm" "polyMirror1.mp";
connectAttr "polyMirror1.out" "polyExtrudeFace1.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace1.mp";
connectAttr "polyTweak1.out" "polyExtrudeFace2.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace2.mp";
connectAttr "polyExtrudeFace1.out" "polyTweak1.ip";
connectAttr "polyTweak2.out" "polyExtrudeFace3.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace3.mp";
connectAttr "polyExtrudeFace2.out" "polyTweak2.ip";
connectAttr "polyTweak3.out" "polyExtrudeFace4.ip";
connectAttr "pCubeShape1.wm" "polyExtrudeFace4.mp";
connectAttr "polyExtrudeFace3.out" "polyTweak3.ip";
connectAttr "polyExtrudeFace4.out" "polyTweak4.ip";
connectAttr "polyTweak4.out" "deleteComponent1.ig";
connectAttr "deleteComponent1.og" "polyTweakUV1.ip";
connectAttr "polyTweak5.out" "polyMergeVert1.ip";
connectAttr "pCubeShape1.wm" "polyMergeVert1.mp";
connectAttr "polyTweakUV1.out" "polyTweak5.ip";
connectAttr "polyMergeVert1.out" "polyMirror2.ip";
connectAttr "pCubeShape1.wm" "polyMirror2.mp";
connectAttr "defaultRenderLayer.msg" ":defaultRenderingList1.r" -na;
connectAttr "pCubeShape1.iog" ":initialShadingGroup.dsm" -na;
connectAttr "Escalera_de_PapelShape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "Avion_de_PapelShape.iog" ":initialShadingGroup.dsm" -na;
connectAttr "Puente_de_PapelShape.iog" ":initialShadingGroup.dsm" -na;
// End of Origamis 3D.ma
