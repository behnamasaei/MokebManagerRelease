import type { AggregateRoot } from './volo/abp/domain/entities/models';
import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';
import type { Gender } from './gender.enum';
import type { MokebDto, ZaerDto } from './domain/dtos/models';
import type { IFormFile } from './microsoft/asp-net-core/http/models';

export interface BlobDto {
  content: number[];
  name?: string;
}

export interface ClockEntryExit extends AggregateRoot<string> {
  zaerId?: string;
  zaer: Zaer;
  entryExitClock?: string;
}

export interface ClockEntryExitDto extends EntityDto<string> {
  zaerId?: string;
  zaer: Zaer;
  entryExitClock?: string;
}

export interface CreateUpdateClockEntryExitDto {
  zaerId?: string;
  entryExitClock?: string;
}

export interface CreateUpdateMokebStateDto {
  mokebId?: string;
  zaerId?: string;
  state: number;
}

export interface CreateZaerDto extends EntityDto<string> {
  name?: string;
  gender: Gender;
  passportNo: string;
  mokebId: string;
  phoneNumber?: number;
  state?: string;
  city?: string;
  address?: string;
}

export interface EntryExitZaer extends AggregateRoot<string> {
  zaerId?: string;
  zaer: Zaer;
  entryDate?: string;
  exitDate?: string;
  mokebId?: string;
}

export interface GetBlobRequestDto {
  name: string;
}

export interface Mokeb extends AggregateRoot<string> {
  name?: string;
  gender: Gender;
  capacity: number;
  address?: string;
  location?: string;
  zaers: Zaer[];
  entryExitZaers: EntryExitZaer[];
  mokebStates: MokebState[];
}

export interface MokebCapacityDto {
  mokebId?: string;
  mokeb: MokebDto;
  freeCapacityToNight: number;
}

export interface MokebState extends AggregateRoot<string> {
  mokebId?: string;
  mokeb: Mokeb;
  zaerId?: string;
  zaer: Zaer;
  state: number;
}

export interface MokebStateDto extends AuditedEntityDto<string> {
  mokebId?: string;
  mokeb: MokebDto;
  zaerId?: string;
  zaer: ZaerDto;
  state: number;
}

export interface SaveBlobInputDto {
  content: number[];
  name: string;
}

export interface UpdateZaerDto {
  name?: string;
  gender: Gender;
  passportNo: string;
  mokebId: string;
  phoneNumber?: number;
  state?: string;
  city?: string;
  address?: string;
}

export interface UploadFileDto {
  file: IFormFile;
  name: string;
}

export interface Zaer extends AggregateRoot<string> {
  name?: string;
  gender: Gender;
  entryExitZaerDates: EntryExitZaer[];
  clockEntryExits: ClockEntryExit[];
  mokebState: MokebState;
  passportNo?: string;
  mokebId?: string;
  mokeb: Mokeb;
  phoneNumber?: number;
  state?: string;
  city?: string;
  address?: string;
}
