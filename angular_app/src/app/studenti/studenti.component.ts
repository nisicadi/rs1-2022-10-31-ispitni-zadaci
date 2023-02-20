import { Component, OnInit } from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {MojConfig} from "../moj-config";
import {Router} from "@angular/router";
declare function porukaSuccess(a: string):any;
declare function porukaError(a: string):any;

@Component({
  selector: 'app-studenti',
  templateUrl: './studenti.component.html',
  styleUrls: ['./studenti.component.css']
})
export class StudentiComponent implements OnInit {

  title:string = 'angularFIT2';
  ime_prezime:string = '';
  opstina: string = '';
  studentPodaci: any;
  filter_ime_prezime: boolean;
  filter_opstina: boolean;
  showModal: boolean;
  selectedStudent: any;
  defaultOpstina: any;
  studentAction: any;


  constructor(private httpKlijent: HttpClient, private router: Router) {
  }

  testirajWebApi() :void
  {
    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll", MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;
    });
  }

  ngOnInit(): void {
    this.testirajWebApi();
    this.defaultOpstina = 2;
  }

  getFiltered() {
    if(!this.filter_opstina && !this.filter_ime_prezime)
      this.testirajWebApi();

    this.httpKlijent.get(MojConfig.adresa_servera+ "/Student/GetAll?ime_prezime="+(this.filter_ime_prezime ? this.ime_prezime : ''), MojConfig.http_opcije()).subscribe(x=>{
      this.studentPodaci = x;

      if(this.filter_opstina)
        this.studentPodaci = this.studentPodaci.filter((s: any) => s.opstina_rodjenja.description.toLowerCase().startsWith(this.opstina.toLowerCase()));
    });
  }

  addStudent() {
    this.selectedStudent = {
      id: 0,
      ime: (this.filter_ime_prezime && this.ime_prezime? this.ime_prezime[0].toUpperCase() + this.ime_prezime.substr(0).toLowerCase() : ''),
      prezime: '',
      opstina_rodjenja_id: this.defaultOpstina
    }
    this.studentAction = 'Dodaj';
    this.showModal = true;
  }

  editStudent(s: any) {
    this.selectedStudent = s;
    this.studentAction = 'Izmijeni';
    this.showModal = true;
  }

  otvaranjeAdd($event: any) {
    this.showModal = $event;

    if(!this.showModal)
      this.getFiltered();
  }
}
