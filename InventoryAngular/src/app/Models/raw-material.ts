export class RawMaterial
{
  id: number;
  rawMaterialID: string;
  rawMaterialCode: string;
  rawMaterialName: string;
  unitPrice: number;
  creationDateTime: string;
  lastModifiedDateTime: string;

  constructor(ID: number, RawMaterialID: string, RawMaterialCode: string, RawMaterialName: string, UnitPrice: number, CreationDateTime: string, LastModifiedDateTime: string)
  {
    this.id = ID;
    this.rawMaterialID = RawMaterialID;
    this.rawMaterialCode = RawMaterialCode;
    this.rawMaterialName = RawMaterialName;
    this.unitPrice = UnitPrice;
    this.creationDateTime = CreationDateTime;
    this.lastModifiedDateTime = LastModifiedDateTime;
  }
}


