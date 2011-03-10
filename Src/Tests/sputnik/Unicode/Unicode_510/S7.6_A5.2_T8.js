// Copyright 2009 the Sputnik authors.  All rights reserved.
// This code is governed by the BSD license found in the LICENSE file.

/**
 * @name: S7.6_A5.2_T8;
 * @section: 7.6, 6;
 * @assertion: If a \UnicodeEscapeSequence sequence were replaced by its UnicodeEscapeSequence's CV, the result must still be a valid Identifier that has the exact same sequence of characters as the original Identifier;
 * @description: The CV of UnicodeEscapeSequence is Mc.
 * Complex test with eval;
*/

//CHECK
Mc = [[0x0903, 0x0903], [0x093E, 0x0940], [0x0949, 0x094C], [0x0982, 0x0983], [0x09BE, 0x09C0], [0x09C7, 0x09C8], [0x09CB, 0x09CC], [0x09D7, 0x09D7], [0x0A03, 0x0A03], [0x0A3E, 0x0A40], [0x0A83, 0x0A83], [0x0ABE, 0x0AC0], [0x0AC9, 0x0AC9], [0x0ACB, 0x0ACC], [0x0B02, 0x0B03], [0x0B3E, 0x0B3E], [0x0B40, 0x0B40], [0x0B47, 0x0B48], [0x0B4B, 0x0B4C], [0x0B57, 0x0B57], [0x0BBE, 0x0BBF], [0x0BC1, 0x0BC2], [0x0BC6, 0x0BC8], [0x0BCA, 0x0BCC], [0x0BD7, 0x0BD7], [0x0C01, 0x0C03], [0x0C41, 0x0C44], [0x0C82, 0x0C83], [0x0CBE, 0x0CBE], [0x0CC0, 0x0CC4], [0x0CC7, 0x0CC8], [0x0CCA, 0x0CCB], [0x0CD5, 0x0CD6], [0x0D02, 0x0D03], [0x0D3E, 0x0D40], [0x0D46, 0x0D48], [0x0D4A, 0x0D4C], [0x0D57, 0x0D57], [0x0D82, 0x0D83], [0x0DCF, 0x0DD1], [0x0DD8, 0x0DDF], [0x0DF2, 0x0DF3], [0x0F3E, 0x0F3F], [0x0F7F, 0x0F7F], [0x102B, 0x102C], [0x1031, 0x1031], [0x1038, 0x1038], [0x103B, 0x103C], [0x1056, 0x1057], [0x1062, 0x1064], [0x1067, 0x106D], [0x1083, 0x1084], [0x1087, 0x108C], [0x108F, 0x108F], [0x17B6, 0x17B6], [0x17BE, 0x17C5], [0x17C7, 0x17C8], [0x1923, 0x1926], [0x1929, 0x192B], [0x1930, 0x1931], [0x1933, 0x1938], [0x19B0, 0x19C0], [0x19C8, 0x19C9], [0x1A19, 0x1A1B], [0x1B04, 0x1B04], [0x1B35, 0x1B35], [0x1B3B, 0x1B3B], [0x1B3D, 0x1B41], [0x1B43, 0x1B44], [0x1B82, 0x1B82], [0x1BA1, 0x1BA1], [0x1BA6, 0x1BA7], [0x1BAA, 0x1BAA], [0x1C24, 0x1C2B], [0x1C34, 0x1C35], [0xA823, 0xA824], [0xA827, 0xA827], [0xA880, 0xA881], [0xA8B4, 0xA8C3], [0xA952, 0xA953], [0xAA2F, 0xAA30], [0xAA33, 0xAA34], [0xAA4D, 0xAA4D]];

errorCount = 0;
count = 0;
for (indexI = 0; indexI < Mc.length; indexI++) {
  for (indexJ = Mc[indexI][0]; indexJ <= Mc[indexI][1]; indexJ++) {
    try {
      var hex = decimalToHexString(indexJ);
      var identifier1 = "$" + String.fromCharCode(indexJ);
      var identifier2 = "$\\u" + hex;
      eval(identifier2 + " = 1"); 
      if (eval(identifier1 + " === " + identifier2) !== true) {
        $ERROR('#' + hex + ' ');
        errorCount++;
      }
    } catch (e) {
      $ERROR('#' + hex + ' ');
      errorCount++;
    }
    count++;
  }
}

if (errorCount > 0) {    
  $ERROR('Total error: ' + errorCount + ' bad Unicode character in ' + count);
}

function decimalToHexString(n) {
  n = Number(n);
  var h = "";
  for (var i = 3; i >= 0; i--) {
    if (n >= Math.pow(16, i)) {
      var t = Math.floor(n / Math.pow(16, i));
      n -= t * Math.pow(16, i);
      if ( t >= 10 ) {
        if ( t == 10 ) { h += "A"; }
        if ( t == 11 ) { h += "B"; }
        if ( t == 12 ) { h += "C"; }
        if ( t == 13 ) { h += "D"; }
        if ( t == 14 ) { h += "E"; }
        if ( t == 15 ) { h += "F"; }
      } else {
        h += String(t);
      }
    } else {
      h += "0";
    }
  }
  return h;
}