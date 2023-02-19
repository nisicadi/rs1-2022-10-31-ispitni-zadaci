import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";
import { formatDate } from '@angular/common';

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {
  upisAkGodina: any;
  student: any;
  studentId: number;
  maticnaKnjiga: any;
  akGodine: any;
  showUpisModal: boolean;
  upisDatum: any;
  upisGodina: number;
  upisCijena: number;
  upisObnova: boolean;
  showOvjeraModal: boolean;
  ovjeraDatum: any;
  ovjeraNapomena: any;
  ovjeraId: number;

  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {}
  getStudent(id: number)
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetById?id="+id, MojConfig.http_opcije()).subscribe(x=>{
      this.student = x;
    });
  }

  getMaticnaKnjiga(id: number)
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/MaticnaKnjiga/Get?id="+id, MojConfig.http_opcije()).subscribe(x=>{
      this.maticnaKnjiga = x;
    });
  }

  getAkGodine()
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/AkademskeGodine/GetAll_ForCmb", MojConfig.http_opcije()).subscribe(x=>{
      this.akGodine = x;
    });
  }

  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {

  }

  ngOnInit(): void {
    this.route.params.subscribe((s: any) => {
      this.studentId = +s["id"];
      this.getStudent(this.studentId);
    });

    this.getStudent(this.studentId);
    this.getMaticnaKnjiga(this.studentId);
    this.getAkGodine();
  }

  dodajZimski() {
    var newUpis = {
      studentId: this.studentId,
      datumUpisaZ: this.upisDatum,
      godinaStudija: this.upisGodina,
      akademskaGodinaId: this.upisAkGodina,
      cijenaSkolarine: this.upisCijena,
      isObnova: this.upisObnova
    }
    this.httpKlijent.post(MojConfig.adresa_servera+ "/MaticnaKnjiga/Post", newUpis, MojConfig.http_opcije()).subscribe(x=>{
      this.getMaticnaKnjiga(this.studentId);
    });

    this.showUpisModal = false;
  }

  ovjeriSemestar() {
    var zaOvjeru = {
      id: this.ovjeraId,
      studentId: this.studentId,
      datumOvjere: this.ovjeraDatum,
      napomenaOvjera: this.ovjeraNapomena
    }

    this.httpKlijent.post(MojConfig.adresa_servera+ "/MaticnaKnjiga/Ovjera", zaOvjeru, MojConfig.http_opcije()).subscribe(x=>{
      this.getMaticnaKnjiga(this.studentId);
    });

    this.showOvjeraModal = false;
  }

  pripremiOvjeru(z: any) {
    this.ovjeraDatum = new Date();
    this.ovjeraId = z.id;
    this.showOvjeraModal = true;
  }
}
