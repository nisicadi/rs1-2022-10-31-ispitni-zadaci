import { Component, OnInit } from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {MojConfig} from "../moj-config";
import {HttpClient} from "@angular/common/http";

declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-student-maticnaknjiga',
  templateUrl: './student-maticnaknjiga.component.html',
  styleUrls: ['./student-maticnaknjiga.component.css']
})
export class StudentMaticnaknjigaComponent implements OnInit {
  constructor(private httpKlijent: HttpClient, private route: ActivatedRoute) {}
  id: number;
  student: any;
  godine: any;
  akGodine: any;
  upisAkGod: number;
  upisDatum: any;
  showModal: boolean;
  upisGodina: any;
  upisCijena: any;
  isObnova: any;
  showOvjera: boolean;
  zaOvjeru: any;
  ovjeraDatum: any;
  ovjeraNapomena: any;

  getStudent() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetById?id="+this.id, MojConfig.http_opcije()).subscribe(x=>{
      this.student = x;
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe((s: any) => {
      this.id = +s["id"];
      this.getStudent();
    })

    this.httpKlijent.get(MojConfig.adresa_servera+ "/AkademskeGodine/GetAll_ForCmb", MojConfig.http_opcije()).subscribe(x=>{
      this.akGodine = x;
    });

    this.getGodine();
    this.upisAkGod = 1;
  }

  saveChanges() {
    let noviSemestar = {
      id: 0,
      studentId: this.id,
      datumUpisa: this.upisDatum,
      godinaStudija: this.upisGodina,
      akademskaGodinaId: this.upisAkGod,
      cijenaSkolarine: this.upisCijena,
      isObnova: this.isObnova
    }

    this.httpKlijent.post(MojConfig.adresa_servera+ "/MaticnaKnjiga/SaveChanges", noviSemestar, MojConfig.http_opcije()).subscribe(x=>{
      this.getGodine();
    });
  }

  private getGodine() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/MaticnaKnjiga/GetByStudent?id="+this.id, MojConfig.http_opcije()).subscribe(x=>{
      this.godine = x;
    });
  }

  ovjeraSemestra(g: any) {
    this.zaOvjeru = g;
    this.showOvjera = true;
    this.ovjeraDatum = new Date();
  }

  ovjeriSemestar() {
    let ovjera = {
      id: this.zaOvjeru.id,
      datumOvjere: this.ovjeraDatum,
      ovjeraNapomena: this.ovjeraNapomena
    }

    this.httpKlijent.post(MojConfig.adresa_servera+ "/MaticnaKnjiga/SaveChanges", ovjera, MojConfig.http_opcije()).subscribe(x=>{
      this.getGodine();
    });

    this.showOvjera = false;
  }
}
