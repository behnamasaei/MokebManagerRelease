import { AuthService, LocalizationService, LocalizationWithDefault } from '@abp/ng.core';
import { Component } from '@angular/core';
import { MenuItem, MessageService } from 'primeng/api';
import Tesseract from 'tesseract.js';
import { OcrService } from '../services/ocr.service';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
  providers: [MessageService],
})
export class HomeComponent {
  ocrResult: string | null = null;
  tooltipItems: MenuItem[] | undefined;
  TooltipItems: MenuItem[] | undefined;
  items: MenuItem[] | undefined;
  localizations: string;

  /**
   *
   */
  constructor(
    private authService: AuthService,
    private messageService: MessageService,
    private ocrService: OcrService,
    private localizationService: LocalizationService,
    private router: Router,
    private titleService: Title
  ) {}

  onFileSelected(event: any): void {
    const file: File = event.target.files[0];
    if (file) {
      this.ocrService.recognize(file).then(({ data: { text } }) => {
        this.ocrResult = text;
      });
    }
  }

  ngOnInit() {
    this.titleService.setTitle('مدیریت موکب | خانه');

    // if (!this.hasLoggedIn) {
    //   this.login();
    // }

    this.items = [
      {
        label: 'زائرجدید',
        icon: 'pi pi-plus',
        command: () => this.router.navigate(['./new-zaer']),
        style: { margin: '10px 0px' },
      },
      {
        label: 'زائرجدید با شناسه',
        icon: 'pi pi-qrcode',
        command: () => this.router.navigate(['./new-zaer-id']),
        style: { margin: '10px 0px' },
      },
      {
        label: 'ثبت ساعت عبور و مرور',
        icon: 'pi pi-calendar-minus',
        command: () => this.router.navigate(['./clock-entry-exit']),
        style: { margin: '10px 0px' },
      },
      {
        label: 'ثبت خروج',
        icon: 'pi pi-clock',
        command: () => this.router.navigate(['./exit-date']),
        style: { margin: '10px 0px' },
      },
      {
        label: 'تمدید پذیرش',
        icon: 'pi pi-calendar-plus',
        command: () => this.router.navigate(['./reservation']),
        style: { margin: '10px 0px' },
      },
    ];
  }

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  login() {
    // this.router.navigate(['mokeb-account', 'login']);
    // this.authService.navigateToLogin();
  }
}
