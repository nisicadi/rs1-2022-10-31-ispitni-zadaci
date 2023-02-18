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
  showModal: boolean;
  studentId: number;

  maticnaKnjigaPodaci: any;
  akGodine: any;
  semestarDatum: any;
  semestarAkGodina: any;
  semestarGod: any;
  semestarCijena: any;
  semestarObnova: any;

  ovjeriLjetni(s:any) {

  }

  upisLjetni(s:any) {

  }

  ovjeriZimski(s:any) {

  }

  getmaticnaKnjigaPodaci(id: number) {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/MaticnaKnjiga/GetByID?id="+id.toString(), MojConfig.http_opcije()).subscribe(x=>{
      this.maticnaKnjigaPodaci = x;
    });
  }

  getAkademskeGodine() {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/AkademskeGodine/GetAll_ForCmb", MojConfig.http_opcije()).subscribe(x=>{
      this.akGodine = x;
    });
  }

  ngOnInit(): void {
    this.showModal = false;
    this.route.params.subscribe(s=> {
      this.studentId = +s["id"];
    })
    this.getAkademskeGodine();
    this.getmaticnaKnjigaPodaci(this.studentId);
  }

  saveChanges() {
    let semestar = {
      godinaStudija: this.semestarGod,
      isObnova: this.semestarObnova,
      datumUpisZimski: this.semestarDatum,
      upisAkGodID: +this.semestarAkGodina
    }

    this.httpKlijent.get(MojConfig.adresa_servera+ "/AkademskeGodine/SaveChanges", MojConfig.http_opcije()).subscribe(x=>{
      this.getAkademskeGodine();
    });

    this.showModal = false;
  }
}
